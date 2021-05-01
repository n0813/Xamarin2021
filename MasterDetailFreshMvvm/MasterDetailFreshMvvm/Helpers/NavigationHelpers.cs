using System;
using MasterDetailFreshMvvm.Servicios;

namespace MasterDetailFreshMvvm.Helpers
{
    public static class NavigationHelpers
    {

        static INavigationServices currentInstante;

        public static INavigationServices instance
        {
            get
            {
                if (currentInstante == null)
                {
                    currentInstante = new NavigationService();
                    return currentInstante;
                }
                return currentInstante;
            }

            set => currentInstante = value;
        }


    }
}
