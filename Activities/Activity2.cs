using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Content.PM;
using NavDrawer.Helpers;

namespace NavDrawer.Activities
{
    [Activity(
        Label = "Xamarin Nav Drawer",
        LaunchMode = LaunchMode.SingleTop,
        Theme = "@style/MyTheme"
    )]
    public class Activity2 : ActionBarActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity2_view);
            this.Title = "Activity 2";

            Global.drawerIni(this);
            Global.m_DrawerToggle.SyncState();

            //actionbar home button
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.SupportActionBar.SetHomeButtonEnabled(true);
        }

        /// <summary>
        /// CLICK EVENT
        /// Pass the event to ActionBarDrawerToggle, if it returns
        /// true, then it has handled the app icon touch event
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.flyOutMenuButton:
                    //click on the button "more"
                    Global.m_Drawer.OpenDrawer(Global.m_DrawerList);
                    return true;
                default:
                    //click on the app icon in the actionbar
                    Global.m_Drawer.OpenDrawer(Global.m_DrawerList);
                    return base.OnOptionsItemSelected(item);
            }
        }

        /// <summary>
        /// Menu in action bar onCreate trigger. It will inflate the menu buttons
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Global, menu);

            var flyOutMenuButton = menu.FindItem(Resource.Id.flyOutMenuButton);

            return true;
        }
    }
}