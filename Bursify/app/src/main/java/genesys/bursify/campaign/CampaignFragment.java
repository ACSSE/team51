package genesys.bursify.campaign;


import android.content.res.Configuration;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.astuetz.PagerSlidingTabStrip;

import java.util.ArrayList;
import java.util.List;

import genesys.bursify.R;
import genesys.bursify.ViewPagerAdapter;


/**
 * A simple {@link Fragment} subclass.
 */
public class CampaignFragment extends Fragment
{

    private ViewPager pager;
    private PagerSlidingTabStrip pagerTabs;

    public static CampaignFragment newInstance()
    {
        CampaignFragment campaignFragment = new CampaignFragment();

        Bundle args = new Bundle();

        campaignFragment.setArguments(args);

        return campaignFragment;
    }

    public CampaignFragment()
    {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        setRetainInstance(true);
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_campaign, container, false);

       /* final Toolbar toolBar = (Toolbar) view.findViewById(R.id.tool_bar);
        setSupportActionBar(toolBar);*/

        pagerTabs = (PagerSlidingTabStrip) view.findViewById(R.id.tabs);

        pager = (ViewPager) view.findViewById(R.id.pager);

        ViewPagerAdapter pagerAdapter = new ViewPagerAdapter(getActivity(), getChildFragmentManager(), getFragmentViews(), getFragmentViewTitles());

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

        viewList.add(new AcademicFragment());
        viewList.add(new TripFragment());

        return viewList;
    }

    private List<String> getFragmentViewTitles()
    {
        List<String> viewListTitles = new ArrayList<>();

        viewListTitles.add("Academic");
        viewListTitles.add("Excursions");

        return viewListTitles;
    }

    @Override
    public void onDetach()
    {
        super.onDetach();
        setHasOptionsMenu(false);
    }

    @Override
    public void onDestroyView()
    {
        super.onDestroyView();
        setHasOptionsMenu(false);
    }

}
