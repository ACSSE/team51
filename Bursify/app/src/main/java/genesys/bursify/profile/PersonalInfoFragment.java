package genesys.bursify.profile;


import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.TimePickerDialog;
import android.content.DialogInterface;
import android.graphics.Color;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;
import android.text.format.DateFormat;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.TimePicker;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;
import java.util.StringTokenizer;

import genesys.bursify.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class PersonalInfoFragment extends Fragment implements DatePickerDialog.OnDateSetListener
{
    public EditText dateOfBirth;
    Calendar myCalendar = Calendar.getInstance();
    DatePickerDialog datePickerDialog;

    public PersonalInfoFragment()
    {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_personal_info, container, false);

        dateOfBirth = (EditText) view.findViewById(R.id.dateOfBirth);

        dateOfBirth.setOnTouchListener(new View.OnTouchListener()
        {
            @Override
            public boolean onTouch(View v, MotionEvent event)
            {
                datePickerDialog = new DatePickerDialog(getActivity(), PersonalInfoFragment.this, myCalendar
                        .get(Calendar.YEAR), myCalendar.get(Calendar.MONTH),
                        myCalendar.get(Calendar.DAY_OF_MONTH));

                datePickerDialog.show();

                return false;
            }
        });

        return view;
    }

    private void updateLabel() {

        String myFormat = "yy/MM/dd"; //In which you need put here
        SimpleDateFormat sdf = new SimpleDateFormat(myFormat, Locale.US);

        dateOfBirth.setText(sdf.format(myCalendar.getTime()));
    }

    @Override
    public void onDateSet(DatePicker view, int year, int month, int day)
    {
        myCalendar.set(Calendar.YEAR, year);
        myCalendar.set(Calendar.MONTH, month);
        myCalendar.set(Calendar.DAY_OF_MONTH, day);
        updateLabel();
    }

}
