package genesys.bursify.profile;


import android.content.Intent;
import android.content.res.Configuration;
import android.database.Cursor;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.astuetz.PagerSlidingTabStrip;

import java.util.ArrayList;
import java.util.List;

import genesys.bursify.R;
import genesys.bursify.ViewPagerAdapter;

/**
 * A simple {@link Fragment} subclass.
 */
public class ProfileFragment extends Fragment
{
    private ViewPager pager;
    private PagerSlidingTabStrip pagerTabs;


    public static ProfileFragment newInstance()
    {
        ProfileFragment profileFragment = new ProfileFragment();

        Bundle args = new Bundle();

        profileFragment.setArguments(args);

        return profileFragment;
    }

    public ProfileFragment()
    {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_profile, container, false);

        pagerTabs = (PagerSlidingTabStrip) view.findViewById(R.id.tabs);

        pager = (ViewPager) view.findViewById(R.id.pager);

        ViewPagerAdapter pagerAdapter = new ViewPagerAdapter(getActivity(), getFragmentManager(), getFragmentViews(), getFragmentViewTitles());

        pager.setAdapter(pagerAdapter);


        int screenSize = (getResources().getConfiguration().screenLayout & Configuration.SCREENLAYOUT_SIZE_MASK);

        if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE)
        {
            pagerTabs.setShouldExpand(true);
        }
        else if (screenSize == Configuration.SCREENLAYOUT_SIZE_XLARGE)
        {
            pagerTabs.setShouldExpand(true);

        }
        else
        {
            pagerTabs.setShouldExpand(true);
        }

        pagerTabs.setViewPager(pager);

        pagerTabs.setIndicatorColor(Color.WHITE);
        pagerTabs.setTextColor(Color.WHITE);
        pagerTabs.setVisibility(View.VISIBLE);

        return view;
    }

    private List<Fragment> getFragmentViews()
    {
        List<Fragment> viewList = new ArrayList<>();

        viewList.add(new PersonalInfoFragment());
        viewList.add(new ContactFragment());
        viewList.add(new AcademicInfoFragment());

        return viewList;
    }


    private List<String> getFragmentViewTitles()
    {
        List<String> viewListTitles = new ArrayList<>();

        viewListTitles.add("Personal");
        viewListTitles.add("Contact");
        viewListTitles.add("Academic");

        return viewListTitles;
    }





}
