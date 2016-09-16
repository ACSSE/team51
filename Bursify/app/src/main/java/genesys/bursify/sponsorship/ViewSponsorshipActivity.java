package genesys.bursify.sponsorship;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.text.Spanned;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.TextView;

import org.json.JSONException;
import org.json.JSONObject;

import genesys.bursify.R;
import genesys.bursify.utility.BursifyService;

public class ViewSponsorshipActivity extends AppCompatActivity
{
    private CollapsingToolbarLayout toolbarLayout;
    private TextView sponsorshipName, sponsorshipDescription, sponsorshipClosingDate, sponsorshipTerms;
    private ProgressBar progressBar;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_sponsorship);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setTitle("");

        toolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.toolbar_layout);

        //sponsorshipName = (TextView) findViewById(R.id.sponsorship_name);
        sponsorshipDescription = (TextView) findViewById(R.id.sponsorship_description);
        sponsorshipClosingDate = (TextView) findViewById(R.id.sponsorship_closing_date);
        sponsorshipTerms = (TextView) findViewById(R.id.sponsorship_terms_and_conditions);

        progressBar = (ProgressBar) findViewById(R.id.view_sponsorship_progress);
        if (progressBar != null)
        {
            progressBar.setVisibility(View.GONE);
        }

        new GetSponsorshipDetailsTask().execute();

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
                //sponsorshipName.setText(jsonObject.getString("Name"));
                toolbarLayout.setTitle(jsonObject.getString("Name"));
                sponsorshipDescription.setText(title("Description:").toString() + "\n" + jsonObject.getString("Description") + "\n");
                sponsorshipClosingDate.setText(title("Closing Date:").toString() + "\n" + jsonObject.getString("ClosingDate").substring(0, 10).replaceAll("-", "/") + "\n");
                sponsorshipTerms.setText(title("Terms And Conditions:").toString() + "\n" + jsonObject.getString("TermsAndConditions"));
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
