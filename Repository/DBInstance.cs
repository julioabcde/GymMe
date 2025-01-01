using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repository
{
    public class DBInstance
    {
        private static GymMeEntities instance;
        public static GymMeEntities getInstance()
        {
            if (instance == null)
            {
                instance = new GymMeEntities();
            }
            return instance;
        }
    }
}