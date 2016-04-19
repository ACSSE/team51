package brandon.bursify;

import android.content.Context;
import android.os.Parcelable;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;

import java.util.ArrayList;

/**
 * @author Brandon.
 * Custom adpater for the tabs used in the {@link TabFragment}
 */
public class HomeViewPagerAdapter extends FragmentStatePagerAdapter
{

    private ArrayList<Fragment> fragmentArrayList;
    private Context context;

    /**
     * Create a new adapter using
     * @param context   the activity in which the {@link android.support.v4.view.ViewPager} is used
     * @param manager   fragment manager
     */
    public HomeViewPagerAdapter(Context context, FragmentManager manager)
    {
         super(manager);

        this.context = context;

        fragmentArrayList = new ArrayList<>();
        fragmentArrayList.add(new FragmentOne());
        fragmentArrayList.add(new FragmentTwo());

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
        CharSequence title = "";

        switch(position)
        {
            case 0:

                title = "Bursaries";

                break;

            case 1:

                title = "Campaigns";

                break;

        }

        return title;
    }

    @Override
    public Parcelable saveState()
    {
        return null;
    }
}
