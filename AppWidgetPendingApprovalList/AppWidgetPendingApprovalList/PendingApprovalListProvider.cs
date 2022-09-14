using Android.App;
using Android.Content;
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Widget;

namespace AppWidgetPendingApprovalList
{
    class PendingApprovalListProvider : Java.Lang.Object, RemoteViewsService.IRemoteViewsFactory
    {
        private List<PendingApprovalList> pendingApprovalLists = new List<PendingApprovalList>();
        private Context context;


        public PendingApprovalListProvider(Context contextNew)

        {
            context = contextNew;

            populateListItem();
        }
        public int Count { get { return pendingApprovalLists.Count; } }


        public long GetItemId(int position)
        {
            return position;
        }
        public RemoteViews GetViewAt(int position)
        {
            RemoteViews remoteView = new RemoteViews(context.PackageName, Resource.Layout.list_row);
            if (position % 2 == 0)
            {
                remoteView.SetTextColor(Resource.Id.heading, Android.Graphics.Color.Red);
                remoteView.SetTextColor(Resource.Id.content, Android.Graphics.Color.Red);

            }
            else
            {
                remoteView.SetTextColor(Resource.Id.heading, Android.Graphics.Color.Black);
                remoteView.SetTextColor(Resource.Id.content, Android.Graphics.Color.Black);

            }


            PendingApprovalList pendingApprovalListItem = pendingApprovalLists[position];

            remoteView.SetTextViewText(Resource.Id.heading, pendingApprovalListItem.heading);
            remoteView.SetTextViewText(Resource.Id.content, pendingApprovalListItem.content);

            return remoteView;

        }
        private void populateListItem()
        {
            for (int i = 0; i < 10; i++)
            {
                PendingApprovalList pendingApprovalListItem = new PendingApprovalList();
                pendingApprovalListItem.heading = "Approval " + i;
                pendingApprovalListItem.content = "Approval " +i;
                pendingApprovalLists.Add(pendingApprovalListItem);
            }
        }

        public RemoteViews LoadingView { get { return null; } }

        public int ViewTypeCount { get { return 1; } }

        public bool HasStableIds { get { return true; } }


        public void OnCreate()
        {
            // throw new NotImplementedException();
        }

        public void OnDataSetChanged()
        {
            // throw new NotImplementedException();
        }

        public void OnDestroy()
        {
            // throw new NotImplementedException();
        }
    }
}