package genesys.bursify;

import android.content.Context;
import android.os.Parcelable;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;

import java.util.ArrayList;
import java.util.List;

import genesys.bursify.sponsorship.SponsorshipFragment;

/**
 * @author genesys.
 * Custom adpater for the tabs used in the {@link SponsorshipFragment}
 */
public class ViewPagerAdapter extends FragmentStatePagerAdapter
{

    private List<Fragment> fragmentArrayList;
    private List<String> viewTitles;
    private Context context;

    /**
     * Create a new adapter using
     * @param context   the activity in which the {@link android.support.v4.view.ViewPager} is used
     * @param manager   fragment manager
     */
    public ViewPagerAdapter(Context context, FragmentManager manager, List<Fragment> views, List<String> viewTitles)
    {
         super(manager);

        this.context = context;

        fragmentArrayList = views;
        this.viewTitles = viewTitles;
    }


    @Override
    public int getCount() {
        return fragmentArrayList.size();
    }

    @Override
    public Fragment getItem(int position) {

        return fragmentArrayList.get(position);

    }

    @Override
    public CharSequence getPageTitle(int position) {
        /*CharSequence title = "";

        switch(position)
        {
            case 0:

                title = viewTitles.get(position);

                break;

            case 1:

                title = "Campaigns";

                break;

        }*/

        return viewTitles.get(position);
    }

    @Override
    public Parcelable saveState()
    {
        return null;
    }
}
