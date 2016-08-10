package genesys.bursify.profile;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import genesys.bursify.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class AcademicInfoFragment extends Fragment
{


    public AcademicInfoFragment()
    {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_academic_info, container, false);
    }

}
