using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppWidgetPendingApprovalList
{
    [Service(Permission = "android.permission.BIND_REMOTEVIEWS", Exported = false)]
    public class WidgetService : RemoteViewsService
    {
        public override IRemoteViewsFactory OnGetViewFactory(Intent intent)
        {
            //    int appWidgetId = intent.GetIntExtra(AppWidgetManager.ExtraAppwidgetId, AppWidgetManager.InvalidAppwidgetId);

            PendingApprovalListProvider pendingApprovalListProvider = new PendingApprovalListProvider(this.ApplicationContext);
            return pendingApprovalListProvider;
        }
    }
}