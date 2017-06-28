package md553ddadd68d7e9d9bb09dd09eec5c3780;


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
		mono.android.Runtime.register ("project_4_algemeen.androidTextBoxAdapter, project 4 android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", androidTextBoxAdapter.class, __md_methods);
	}


	public androidTextBoxAdapter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == androidTextBoxAdapter.class)
			mono.android.TypeManager.Activate ("project_4_algemeen.androidTextBoxAdapter, project 4 android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
