package md54c5a65637a7c6daaf3da1300b1e04287;


public class androidTextBoxAdapter
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("project_4_android.androidTextBoxAdapter, project 4 android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", androidTextBoxAdapter.class, __md_methods);
	}


	public androidTextBoxAdapter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == androidTextBoxAdapter.class)
			mono.android.TypeManager.Activate ("project_4_android.androidTextBoxAdapter, project 4 android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
