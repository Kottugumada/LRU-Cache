using System;

namespace LRU_Cache
	{
	class Program
		{
		static void Main(string[] args)
			{
			LRUCache lruCache = new LRUCache(2);
			lruCache.Put(1,1);
			lruCache.Put(2, 2);
			Console.Write(lruCache.Get(1));
			lruCache.Put(3, 3);
			Console.Write(lruCache.Get(2));
			lruCache.Put(4, 4);
			Console.Write(lruCache.Get(1));
			Console.Write(lruCache.Get(3));
			Console.Write(lruCache.Get(4));
			Console.ReadKey();
			}
		}
	}
