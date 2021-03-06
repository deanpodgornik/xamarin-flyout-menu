using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;

using NavDrawer.Helpers;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Content;

namespace NavDrawer.Activities
{
	[Activity(
        Label = "Xamarin FlyOut menu", 
        MainLauncher = true, 
        LaunchMode = LaunchMode.SingleTop,
        Theme = "@style/MyTheme"
    )]
	public class Activity1 : ActionBarActivity
	{
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity1_view);
			this.Title = "Home";
            //Global.m_Title = Global.m_DrawerTitle = this.Title;

            FlyOutMenuHelper.drawerIni(this);
            FlyOutMenuHelper.m_DrawerToggle.SyncState();

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
                    FlyOutMenuHelper.m_Drawer.OpenDrawer(FlyOutMenuHelper.m_DrawerList);
                    return true;
                default:
                    //click on the app icon in the actionbar
                    FlyOutMenuHelper.m_Drawer.OpenDrawer(FlyOutMenuHelper.m_DrawerList);
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

        /*
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            Global.m_DrawerToggle.OnConfigurationChanged(newConfig);
        }
        */

        /*
        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            var drawerOpen = Global.m_Drawer.IsDrawerOpen(Global.m_DrawerList);
            //when open don't show anything
            for (int i = 0; i < menu.Size(); i++)
                menu.GetItem(i).SetVisible(!drawerOpen);

            return base.OnPrepareOptionsMenu(menu);
        }
        */
	}
}

