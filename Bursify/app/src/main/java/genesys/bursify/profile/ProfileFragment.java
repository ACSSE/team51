package genesys.bursify.profile;


import android.content.Intent;
import android.content.res.Configuration;
import android.database.Cursor;
import android.graphics.Bitmap;
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
import android.widget.Toast;

import com.astuetz.PagerSlidingTabStrip;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;
import java.util.List;

import genesys.bursify.R;
import genesys.bursify.ViewPagerAdapter;

/**
 * A simple {@link Fragment} subclass.
 */
public class ProfileFragment extends Fragment
{
    private static final int RESULT_OK = 1;
    private ViewPager pager;
    private PagerSlidingTabStrip pagerTabs;

    private static int RESULT_LOAD_IMAGE = 1;
    private static final int SELECT_PICTURE = 1;


    private String selectedImagePath;
    private ImageView img;


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
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState)
    {
        super.onViewCreated(view, savedInstanceState);

        setHasOptionsMenu(true);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_profile, container, false);

        img = (ImageView) getActivity().findViewById(R.id.profilePicture);

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

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater)
    {
        super.onCreateOptionsMenu(menu, inflater);
        inflater.inflate(R.menu.profile_menu, menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        if(item.getItemId() == R.id.profilePicture)
        {
            Intent intent = new Intent();
            intent.setType("image/*");
            intent.setAction(Intent.ACTION_GET_CONTENT);
            startActivityForResult(Intent.createChooser(intent,
                    "Select Picture"), SELECT_PICTURE);


        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        //super.onActivityResult(requestCode, resultCode, data);

        //if (resultCode == RESULT_OK) {
          //  if (requestCode == SELECT_PICTURE) {
                Uri selectedImageUri = data.getData();
                selectedImagePath = getPath(selectedImageUri);


                Bitmap bitmap = BitmapFactory.decodeFile(selectedImagePath);

//                Picasso.with(getContext())
//                        .load(selectedImageUri)
//                        .into(img);
                img.setImageBitmap(bitmap);
            //}
        //}
    }

    /**
     * helper to retrieve the path of an image URI
     */
    public String getPath(Uri uri) {
        // just some safety built in
        if( uri == null ) {
            // TODO perform some logging or show user feedback
            Toast.makeText(getActivity(), "Image not selected", Toast.LENGTH_SHORT).show();
            return null;
        }
        // try to retrieve the image from the media store first
        // this will only work for images selected from gallery
        String[] projection = { MediaStore.Images.Media.DATA };
        Cursor cursor = getActivity().managedQuery(uri, projection, null, null, null);
        if( cursor != null ){
            int column_index = cursor
                    .getColumnIndexOrThrow(MediaStore.Images.Media.DATA);
            cursor.moveToFirst();
            return cursor.getString(column_index);
        }
        // this is our fallback here
        return uri.getPath();
    }
}
