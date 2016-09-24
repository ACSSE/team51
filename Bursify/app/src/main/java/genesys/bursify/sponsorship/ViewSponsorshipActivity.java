package genesys.bursify.sponsorship;

import android.content.SharedPreferences;
import android.graphics.PorterDuff;
import android.graphics.drawable.LayerDrawable;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.design.widget.AppBarLayout;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.design.widget.CoordinatorLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.CardView;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.text.Layout;
import android.text.Spanned;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ProgressBar;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONException;
import org.json.JSONObject;

import java.text.SimpleDateFormat;
import java.util.Date;

import genesys.bursify.R;
import genesys.bursify.data.models.SponsorshipResponse;
import genesys.bursify.utility.BursifyService;
import genesys.bursify.utility.CustomCard;
import genesys.bursify.utility.FragmentUtility;
import it.gmariotti.cardslib.library.internal.Card;
import it.gmariotti.cardslib.library.internal.CardExpand;
import it.gmariotti.cardslib.library.internal.CardHeader;
import it.gmariotti.cardslib.library.internal.ViewToClickToExpand;
import it.gmariotti.cardslib.library.internal.base.BaseCard;
import it.gmariotti.cardslib.library.view.CardViewNative;

public class ViewSponsorshipActivity extends AppCompatActivity
{
    private CollapsingToolbarLayout toolbarLayout;
    private AppBarLayout appBarLayout;
    private RatingBar ratingBar;
    private CardExpand aboutExpand, termExpand, expenseExpand, requirementExpand, studyFieldExpand;
    private TextView sponsorshipName, closingDate, average, daysLeft;
    private ProgressBar progressBar;
    String info = "";
    int id;
    private ApplyForSponsorshipTask applicationTask;
    private Button btnApply;
    private CardViewNative descriptionCard, termsCard, expensesCard, requirementCard, studyFieldCard;
    private Card aboutCard, conditionCard, expenseCard, requireCard, fieldCard;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_sponsorship);
        final Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        id = ViewSponsorshipActivity.this.getIntent().getIntExtra("sponsorshipId", 1);

        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(this);
        final int userId = preferences.getInt("userId", 0);

        if (getSupportActionBar() != null)
        {
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
            getSupportActionBar().setTitle("");
        }

        btnApply = (Button) findViewById(R.id.btnApply);

        btnApply.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                applicationTask = new ApplyForSponsorshipTask(userId, id);
                applicationTask.execute();
            }
        });

        appBarLayout = (AppBarLayout) findViewById(R.id.app_bar);
        toolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.toolbar_layout);

        average = (TextView) findViewById(R.id.txtAverage);
        daysLeft = (TextView) findViewById(R.id.txtDaysLeft);
        ratingBar = (RatingBar) findViewById(R.id.ratingBar);
        closingDate = (TextView) findViewById(R.id.closingDate);
        sponsorshipName = (TextView) findViewById(R.id.bursaryTitle);

        progressBar = (ProgressBar) findViewById(R.id.view_sponsorship_progress);
        if (progressBar != null)
        {
            progressBar.setVisibility(View.GONE);
        }

        new GetSponsorshipDetailsTask().execute();

        initViews();

        aboutCard.setExpanded(true);

        LayerDrawable stars = (LayerDrawable) ratingBar.getProgressDrawable();
        stars.getDrawable(2).setColorFilter(getResources().getColor(R.color.amber), PorterDuff.Mode.SRC_ATOP);
        stars.getDrawable(0).setColorFilter(getResources().getColor(R.color.amber), PorterDuff.Mode.SRC_ATOP);
        stars.getDrawable(1).setColorFilter(getResources().getColor(R.color.amber), PorterDuff.Mode.SRC_ATOP);
    }

    private void initViews()
    {
        descriptionCard = (CardViewNative) findViewById(R.id.sponsorshipDescription);
        expensesCard = (CardViewNative) findViewById(R.id.sponsorshipExpenses);
        requirementCard = (CardViewNative) findViewById(R.id.sponsorshipRequirements);
        studyFieldCard = (CardViewNative) findViewById(R.id.sponsorshipStudyFields);
        termsCard = (CardViewNative) findViewById(R.id.sponsorshipTerms);

        aboutCard = new Card(getApplicationContext());
        conditionCard = new Card(getApplicationContext());
        expenseCard = new Card(getApplicationContext());
        requireCard = new Card(getApplicationContext());
        fieldCard = new Card(getApplicationContext());

        aboutExpand = new CardExpand(this);
        termExpand = new CardExpand(this);
        expenseExpand = new CardExpand(this);
        requirementExpand = new CardExpand(this);
        studyFieldExpand = new CardExpand(this);

        CardHeader descriptionHeader = new CardHeader(getApplicationContext());
        descriptionHeader.setTitle("Description");
        descriptionHeader.setButtonExpandVisible(true);

        CardHeader expenseHeader = new CardHeader(getApplicationContext());
        expenseHeader.setTitle("Expenses Covered");
        expenseHeader.setButtonExpandVisible(true);

        CardHeader requirementHeader = new CardHeader(getApplicationContext());
        requirementHeader.setTitle("Requirements");
        requirementHeader.setButtonExpandVisible(true);

        CardHeader studyFieldHeader = new CardHeader(getApplicationContext());
        studyFieldHeader.setTitle("Study Fields");
        studyFieldHeader.setButtonExpandVisible(true);

        CardHeader termsHeader = new CardHeader(getApplicationContext());
        termsHeader.setTitle("Terms & Conditions");
        termsHeader.setButtonExpandVisible(true);

        aboutCard.addCardHeader(descriptionHeader);
        conditionCard.addCardHeader(termsHeader);
        expenseCard.addCardHeader(expenseHeader);
        requireCard.addCardHeader(requirementHeader);
        fieldCard.addCardHeader(studyFieldHeader);
    }

    private Spanned title(String t)
    {
        return Html.fromHtml("<b>" + t + "</b>");
    }

    public void setData(SponsorshipResponse response)
    {
        sponsorshipName.setText(response.getName());
        ratingBar.setRating(response.getRating());
        closingDate.setText("Closing date: " + FragmentUtility.createDate(response.getClosingDate()));
        average.setText(response.getAverageMarkRequired() + "%\nAverage");

        int days = FragmentUtility.calculateDaysBetween(FragmentUtility.getDateFrom(response.getClosingDate()), new Date());

        daysLeft.setText(days + 1 + "\nDays left");
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
                ratingBar.setRating(jsonObject.getInt("Rating"));
                closingDate.setText("Closing date: " + FragmentUtility.createDate(jsonObject.getString("ClosingDate")));
                average.setText(jsonObject.getInt("AverageMarkRequired") + "%\nAverage");

                info = jsonObject.getString("Description");

                int days = FragmentUtility.calculateDaysBetween(FragmentUtility.getDateFrom(jsonObject.getString("ClosingDate")), new Date());

                daysLeft.setText(days + 1 + "\nDays left");

                aboutExpand.setTitle(info);
                termExpand.setTitle(jsonObject.getString("TermsAndConditions"));
                expenseExpand.setTitle(formatInfo(jsonObject.getString("ExpensesCovered")));
                //requirementExpand.setTitle();
                studyFieldExpand.setTitle(formatInfo(jsonObject.getString("StudyFields")));
                //card.setExpanded(true);
                aboutCard.addCardExpand(aboutExpand);
                conditionCard.addCardExpand(termExpand);
                expenseCard.addCardExpand(expenseExpand);
                requireCard.addCardExpand(requirementExpand);
                fieldCard.addCardExpand(studyFieldExpand);

                ViewToClickToExpand viewToClickToExpand = ViewToClickToExpand.builder().enableForExpandAction();
                aboutCard.setViewToClickToExpand(viewToClickToExpand);
                conditionCard.setViewToClickToExpand(viewToClickToExpand);
                expenseCard.setViewToClickToExpand(viewToClickToExpand);
                requireCard.setViewToClickToExpand(viewToClickToExpand);
                fieldCard.setViewToClickToExpand(viewToClickToExpand);


                aboutCard.setOnClickListener(new Card.OnCardClickListener()
                {
                    @Override
                    public void onClick(Card card, View view)
                    {
                        card.doToogleExpand();
                    }
                });

                conditionCard.setOnClickListener(new Card.OnCardClickListener()
                {
                    @Override
                    public void onClick(Card card, View view)
                    {
                        card.doToogleExpand();
                    }
                });

                expenseCard.setOnClickListener(new Card.OnCardClickListener()
                {
                    @Override
                    public void onClick(Card card, View view)
                    {
                        card.doToogleExpand();
                    }
                });

                requireCard.setOnClickListener(new Card.OnCardClickListener()
                {
                    @Override
                    public void onClick(Card card, View view)
                    {
                        card.doToogleExpand();
                    }
                });

                fieldCard.setOnClickListener(new Card.OnCardClickListener()
                {
                    @Override
                    public void onClick(Card card, View view)
                    {
                        card.doToogleExpand();
                    }
                });

                descriptionCard.setCard(aboutCard);
                termsCard.setCard(conditionCard);
                expensesCard.setCard(expenseCard);
                requirementCard.setCard(requireCard);
                studyFieldCard.setCard(fieldCard);

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

        private String formatInfo(String info)
        {
            String[] data = info.split(",");

            String strReturn = "";

            for (String s : data)
            {
                strReturn += s + "\n\n";
            }

            return strReturn;
        }
    }

    class ApplyForSponsorshipTask extends AsyncTask<Void, Void, JSONObject>
    {
        private int studentId, sponsorshipId;

        public ApplyForSponsorshipTask(int studentId, int sponsorshipId)
        {
            this.studentId = studentId;
            this.sponsorshipId = sponsorshipId;
        }

        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
        }

        @Override
        protected void onProgressUpdate(Void... values)
        {
            super.onProgressUpdate(values);
        }

        @Override
        protected JSONObject doInBackground(Void... params)
        {
            JSONObject applyObject = new JSONObject();
            JSONObject response;

            try
            {
                SimpleDateFormat sdf = new SimpleDateFormat("MM/dd/yyyy");

                applyObject.accumulate("StudentId", studentId);
                applyObject.accumulate("SponsorshipId", sponsorshipId);
                applyObject.accumulate("ApplicationDate", sdf.format(new Date()));
                applyObject.accumulate("Status", "Pending");
                applyObject.accumulate("SponsorshipOffered", false);

                response = BursifyService.postService(BursifyService.APPLY_FOR_SPONSORSHIP, applyObject);

                return response;
            }
            catch (JSONException e)
            {
                e.printStackTrace();
            }

            return null;
        }

        @Override
        protected void onPostExecute(JSONObject jsonObject)
        {
            super.onPostExecute(jsonObject);
        }
    }
}
