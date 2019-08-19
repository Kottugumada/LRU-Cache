using System;
using System.Collections.Generic;
using System.Text;

namespace LRU_Cache
	{
	public class LRUCache
		{
			public int Capacity { get; set; }
			public Dictionary<int,LinkedListNode<CacheItem>> cacheMap { get; set; }
			public LinkedList<CacheItem> lruList { get; set; }
			public CacheItem lruCacheItem { get; set; } = new CacheItem();
			public LRUCache(int capacity)
			{
				Capacity = capacity;
				cacheMap = new Dictionary<int, LinkedListNode<CacheItem>>();
				lruList = new LinkedList<CacheItem>();
			}

			public int Get(int key)
			{
				if (!cacheMap.ContainsKey(key)) return -1;
				lruList.Remove(cacheMap[key]);
				lruList.AddLast(cacheMap[key]);
				return cacheMap[key].Value.CacheValue;
			}
			public void Put(int key, int value)
			{
				if (cacheMap.ContainsKey(key))
				{
					cacheMap[key].Value.CacheValue = value;
					lruList.Remove(cacheMap[key]);
					lruList.AddLast(cacheMap[key]);
					return;
				}

				if (cacheMap.Count >= Capacity)
				{
					cacheMap.Remove(lruList.First.Value.CacheKey);
					lruList.RemoveFirst();
				}
				cacheMap.Add(key, new LinkedListNode<CacheItem>(new CacheItem { CacheKey = key, CacheValue =  value}));
				lruList.AddLast(cacheMap[key]);
			}
		}
	}
