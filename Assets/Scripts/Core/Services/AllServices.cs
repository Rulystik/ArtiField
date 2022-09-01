using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Instance => _instance ?? (_instance = new AllServices());
        
        public void RegisterService<TService>(TService obj)
        {
            Implementation<TService>.ServiceInstance = obj;
        }
        
        public TService GetService<TService>()
        {
            return Implementation<TService>.ServiceInstance;
        }
    }

    static class Implementation<TService>
    {
        public static TService ServiceInstance { get; set; }
    } 
}