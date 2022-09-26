using ClinicManagementSystem.IServices;
using Microsoft.Extensions.Caching.Memory;

namespace ClinicManagementSystem.Model
{
    public static class CacheNames
    {
        public static string User = "User";
        public static string Patient = "Patient";
        public static string PatientDiagnose = "PatientDiagnose";
        public static string Medicine = "Medicine";
        public static string Admin = "Admin";
    }
    public static class CacheAbsoluteDuration
    {
        public static TimeSpan Admin = new TimeSpan(3, 0, 0);
        public static TimeSpan User = new TimeSpan(3, 0, 0);
        public static TimeSpan Patient = new TimeSpan(3, 0, 0);
        public static TimeSpan PatientDiagnose = new TimeSpan(3, 0, 0);
        public static TimeSpan Medicine = new TimeSpan(3, 0, 0);
    }
    public class CacheManager<T>
    {
        private IService<T> _services;
        private IMemoryCache _memoryCache;
        private string _cacheName;
        private TimeSpan _cacheTime;
        
        public CacheManager(IService<T> services, IMemoryCache memoryCache, string cacheName, TimeSpan cacheTime)
        {
            _memoryCache = memoryCache;
            _cacheName = cacheName;
            _cacheTime = cacheTime;
            _services = services;
        }

        public List<T> GetCache(bool createEmptyCache = false)
        {
            List<T> Values;
            if(!_memoryCache.TryGetValue(_cacheName, out Values))
            {
                Values = _services.GetAll();
                _memoryCache.Set(_cacheName, Values, _cacheTime);
            }

            if (Values == null && createEmptyCache)
                Values = new List<T>();

            return Values;
        }

        public bool AddItemInCache(T item)
        {
            bool result = false;
            List<T> Values;
            if(_memoryCache.TryGetValue(item, out Values))
            {
                if(item != null)
                {
                    Values.Add(item);
                    _memoryCache.Set(_cacheName, Values, _cacheTime);
                }
                return true;
            }
            return result;
        }
        public bool UpdateItemInCache(T oldItem, T newItem)
        {
            bool result = false;
            List<T> Values;
            if(_memoryCache.TryGetValue(_cacheName, out Values))
            {
                if(Values != null && oldItem != null)
                {
                    Values.Remove(oldItem);
                }
                if(newItem != null)
                {
                    Values.Add(newItem);
                }
                result = true;
            }
            return result;
        }
        public bool ClearCache()
        {
            bool result = false;
            List<T> Items;
            if(_memoryCache.TryGetValue(_cacheName, out Items))
            {
                _memoryCache.Remove(Items);
                result = true;
            }
            return result;
        }
        public bool ClearItemFromCache(T oldItem)
        {
            bool result = false;
            List<T> Values;
            if(_memoryCache.TryGetValue(_memoryCache, out Values))
            {
                if(oldItem != null)
                {
                    Values.Remove(oldItem);
                    _memoryCache.Set(_cacheName, Values, _cacheTime);
                    result = true;
                }
            }
            return result;
        }
    }
}
