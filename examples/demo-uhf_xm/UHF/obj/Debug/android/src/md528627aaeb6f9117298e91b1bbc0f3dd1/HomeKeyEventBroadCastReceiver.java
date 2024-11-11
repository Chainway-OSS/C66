package md528627aaeb6f9117298e91b1bbc0f3dd1;


public class HomeKeyEventBroadCastReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("UHF.HomeKeyEventBroadCastReceiver, UHF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", HomeKeyEventBroadCastReceiver.class, __md_methods);
	}


	public HomeKeyEventBroadCastReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HomeKeyEventBroadCastReceiver.class)
			mono.android.TypeManager.Activate ("UHF.HomeKeyEventBroadCastReceiver, UHF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public HomeKeyEventBroadCastReceiver (md528627aaeb6f9117298e91b1bbc0f3dd1.Scan_Fragment p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == HomeKeyEventBroadCastReceiver.class)
			mono.android.TypeManager.Activate ("UHF.HomeKeyEventBroadCastReceiver, UHF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "UHF.Scan_Fragment, UHF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
