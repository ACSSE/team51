package genesys.bursify.sponsorship;


import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ProgressBar;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;

import genesys.bursify.R;
import genesys.bursify.data.entities.Sponsorship;
import genesys.bursify.utility.BursifyService;


/**
 * A simple {@link Fragment} subclass.
 */
public class AllSponsorshipFragment extends Fragment
{
    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private RecyclerView.LayoutManager layoutManager;

    private ProgressBar progressBar;

    private JSONArray sponsorships = null;

    public AllSponsorshipFragment()
    {
        // Required empty public constructor
    }






    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_all_sponsorships, container, false);

        progressBar = (ProgressBar) view.findViewById(R.id.sponsorship_progress);

        recyclerView = (RecyclerView) view.findViewById(R.id.scrollableview);
        recyclerView.setHasFixedSize(true);
        layoutManager = new LinearLayoutManager(getContext());
        recyclerView.setLayoutManager(layoutManager);
        progressBar.setVisibility(View.VISIBLE);
        //new GetSponsorshipTask().execute();
        genesys.bursify.sponsorship.api.Sponsorship sponsorship = new genesys.bursify.sponsorship.api.Sponsorship();

        sponsorship.getAllSponsorships(recyclerView, progressBar);

        //progressBar.setVisibility(View.GONE);

        return view;
    }

    class GetSponsorshipTask extends AsyncTask<Void, Void, Void>
    {
        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();

        }

        @Override
        protected Void doInBackground(Void... params)
        {

            return null;
        }

        @Override
        protected void onProgressUpdate(Void... values)
        {
            super.onProgressUpdate(values);

        }

        @Override
        protected void onPostExecute(Void aVoid)
        {
            super.onPostExecute(aVoid);

        }


        private Sponsorship createSponsorship(JSONObject jsonObject) throws JSONException, ParseException
        {
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd", Locale.getDefault());
            String rawDate = jsonObject.getString("ClosingDate").substring(0, 10).replaceAll("-", "/");

            Date closingDate = sdf.parse(rawDate);
            //jsonObject.na

            Sponsorship s = new Sponsorship(jsonObject.getInt("ID"), jsonObject.getInt("SponsorId"), jsonObject.getString("Name"), jsonObject.getString("Description"), closingDate, jsonObject.getBoolean("EssayRequired"), jsonObject.getDouble("SponsorshipValue"), jsonObject.getString("StudyFields"), jsonObject.getString("Province"), jsonObject.getInt("AverageMarkRequired"), jsonObject.getString("EducationLevel"), jsonObject.getString("InstitutionPreference"), jsonObject.getString("ExpensesCovered"), jsonObject.getString("TermsAndConditions"), jsonObject.getString("SponsorshipType"));
            //sponsorshipList.add(s);
            return s;
        }
    }
}
