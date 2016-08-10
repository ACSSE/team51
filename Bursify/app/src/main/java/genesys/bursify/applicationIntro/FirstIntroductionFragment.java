package genesys.bursify.applicationIntro;


import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import genesys.bursify.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class FirstIntroductionFragment extends Fragment
{


    public FirstIntroductionFragment()
    {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment

        return inflater.inflate(R.layout.fragment_first_introduction, container, false);
    }

}
