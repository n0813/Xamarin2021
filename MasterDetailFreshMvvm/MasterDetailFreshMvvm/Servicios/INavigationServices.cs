using System;
using FreshMvvm;
using MasterDetailFreshMvvm.Enums;

namespace MasterDetailFreshMvvm.Servicios
{
    public interface INavigationServices
    {
        void SwitchNavigation(NavigacionStacks navigationPila, FreshBasePageModel page);

    }
}
