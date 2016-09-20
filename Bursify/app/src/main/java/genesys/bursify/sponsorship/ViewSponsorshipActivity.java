package genesys.bursify.sponsorship;

import android.graphics.PorterDuff;
import android.graphics.drawable.LayerDrawable;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.AppBarLayout;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.design.widget.CoordinatorLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.text.Spanned;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.Date;

import genesys.bursify.R;
import genesys.bursify.utility.BursifyService;
import genesys.bursify.utility.FragmentUtility;

public class ViewSponsorshipActivity extends AppCompatActivity
{
    private CollapsingToolbarLayout toolbarLayout;
    private AppBarLayout appBarLayout;
    private RatingBar ratingBar;
    private TextView sponsorshipName, sponsorshipDescription, sponsorshipClosingDate, sponsorshipTerms, closingDate, average, daysLeft;
    private ProgressBar progressBar;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_sponsorship);
        final Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setTitle("");

        appBarLayout = (AppBarLayout) findViewById(R.id.app_bar);
        toolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.toolbar_layout);

        average = (TextView) findViewById(R.id.txtAverage);
        daysLeft = (TextView) findViewById(R.id.txtDaysLeft);
        ratingBar = (RatingBar) findViewById(R.id.ratingBar);
        closingDate = (TextView) findViewById(R.id.closingDate);
        sponsorshipName = (TextView) findViewById(R.id.bursaryTitle);
        sponsorshipDescription = (TextView) findViewById(R.id.sponsorship_description);
        sponsorshipClosingDate = (TextView) findViewById(R.id.sponsorship_closing_date);
        sponsorshipTerms = (TextView) findViewById(R.id.sponsorship_terms_and_conditions);

        progressBar = (ProgressBar) findViewById(R.id.view_sponsorship_progress);
        if (progressBar != null)
        {
            progressBar.setVisibility(View.GONE);
        }

        new GetSponsorshipDetailsTask().execute();

        LayerDrawable stars = (LayerDrawable) ratingBar.getProgressDrawable();
        stars.getDrawable(2).setColorFilter(getResources().getColor(R.color.amber), PorterDuff.Mode.SRC_ATOP);
        stars.getDrawable(0).setColorFilter(getResources().getColor(R.color.amber), PorterDuff.Mode.SRC_ATOP);
        stars.getDrawable(1).setColorFilter(getResources().getColor(R.color.amber), PorterDuff.Mode.SRC_ATOP);

        appBarLayout.addOnOffsetChangedListener(new AppBarLayout.OnOffsetChangedListener()
        {
            @Override
            public void onOffsetChanged(AppBarLayout appBarLayout, int verticalOffset)
            {
                if(verticalOffset <= -165)
                {
                    toolbarLayout.setTitle(sponsorshipName.getText().toString());
                }
                else
                {
                    toolbarLayout.setTitle("");
                }
            }
        });

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        if (fab != null)
        {
            fab.setOnClickListener(new View.OnClickListener()
            {
                @Override
                public void onClick(View view)
                {
                    Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }
            });
        }
    }

    class GetSponsorshipDetailsTask extends AsyncTask<Void, Void, JSONObject>
    {
        private JSONObject response;

        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
            progressBar.setVisibility(View.VISIBLE);
        }

        @Override
        protected JSONObject doInBackground(Void... params)
        {
            int id = ViewSponsorshipActivity.this.getIntent().getIntExtra("sponsorshipId", 1);

            response = BursifyService.getService(BursifyService.GET_SINGLE_SPONSORSHIP + id);

            return response;
        }

        @Override
        protected void onProgressUpdate(Void... values)
        {
            super.onProgressUpdate(values);

            progressBar.setVisibility(View.VISIBLE);
        }

        @Override
        protected void onPostExecute(JSONObject jsonObject)
        {
            super.onPostExecute(jsonObject);
            progressBar.setVisibility(View.GONE);

            try
            {
                sponsorshipName.setText(jsonObject.getString("Name"));
                //toolbarLayout.setTitle(jsonObject.getString("Name"));
                sponsorshipDescription.setText(title("Description:").toString() + "\n" + jsonObject.getString("Description") + "\n");
                sponsorshipClosingDate.setText(title("Closing Date:").toString() + "\n" + jsonObject.getString("ClosingDate").substring(0, 10).replaceAll("-", "/") + "\n");
                sponsorshipTerms.setText(title("Terms And Conditions:").toString() + "\n" + jsonObject.getString("TermsAndConditions"));
                ratingBar.setRating(jsonObject.getInt("Rating"));
                closingDate.setText("Closing date: " + FragmentUtility.createDate(jsonObject.getString("ClosingDate")));
                average.setText(jsonObject.getInt("AverageMarkRequired") + "%\nAverage");

                int days = FragmentUtility.calculateDaysBetween(FragmentUtility.getDateFrom(jsonObject.getString("ClosingDate")), new Date());

                daysLeft.setText(days+1 + "\nDays left");

            }
            catch (JSONException e)
            {
                e.printStackTrace();
            }
        }

        private Spanned title(String t)
        {
            return Html.fromHtml("<b>" + t + "</b>");
        }
    }
}
