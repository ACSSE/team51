package genesys.bursify.sponsorship;

import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.Typeface;
import android.graphics.drawable.LayerDrawable;
import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RatingBar;
import android.widget.TextView;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

import genesys.bursify.R;
import genesys.bursify.data.entities.Sponsorship;
import genesys.bursify.data.models.SponsorshipResponse;
import genesys.bursify.utility.FragmentUtility;

/**
 * Created by genesys on 2016/04/03.
 */
public class RecyclerViewAdapter extends RecyclerView.Adapter<RecyclerViewAdapter.ViewHolder>
{
    Context context;

    private ArrayList<SponsorshipResponse> sponsorships;

    public RecyclerViewAdapter(ArrayList<SponsorshipResponse> sponsorships)
    {
        this.sponsorships = sponsorships;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType)
    {

        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.card_view, parent, false);
        context = parent.getContext();

        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, int position)
    {

        holder.textView.setText(sponsorships.get(position).getName());
        holder.textView.setTypeface(Typeface.createFromAsset(context.getAssets(), "Roboto-Regular.ttf"));
        holder.txtDescription.setText(sponsorships.get(position).getDescription());
        holder.txtDescription.setTypeface(Typeface.createFromAsset(context.getAssets(), "Roboto-Light.ttf"));
        holder.txtClosingDate.setText(FragmentUtility.createDate(sponsorships.get(position).getClosingDate()));

        holder.ratingBar.setRating(sponsorships.get(position).getRating());
        LayerDrawable stars = (LayerDrawable) holder.ratingBar.getProgressDrawable();
        stars.getDrawable(2).setColorFilter(context.getResources().getColor(R.color.amber), PorterDuff.Mode.SRC_ATOP);
        stars.getDrawable(0).setColorFilter(context.getResources().getColor(R.color.amber), PorterDuff.Mode.SRC_ATOP);
        stars.getDrawable(1).setColorFilter(context.getResources().getColor(R.color.amber), PorterDuff.Mode.SRC_ATOP);

        holder.card.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                String sponsorshipTitle = String.valueOf(holder.textView.getText());

                viewSponsorship(sponsorshipTitle);
            }
        });

    }

    @Override
    public int getItemCount()
    {
        return sponsorships.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder
    {
        TextView textView, txtDescription, txtClosingDate;
        CardView card;
        RatingBar ratingBar;

        public ViewHolder(View view)
        {
            super(view);

            textView = (TextView) view.findViewById(R.id.info_text);
            txtDescription = (TextView) view.findViewById(R.id.txtDescription);
            txtClosingDate = (TextView) view.findViewById(R.id.txtClosingDate);
            card = (CardView) view.findViewById(R.id.card_view);
            ratingBar = (RatingBar) view.findViewById(R.id.rating);


            //ratingBar.setRating(5);
        }
    }

    public Context getContext()
    {
        return context;
    }

    private void viewSponsorship(String sponsorshipName)
    {
        Intent intent = new Intent(context, ViewSponsorshipActivity.class);

        int sponsorshipId;
        for (SponsorshipResponse sponsorship : sponsorships)
        {
            if(sponsorship.getName().equalsIgnoreCase(sponsorshipName))
            {
                //sponsorshipId = ;
                intent.putExtra("sponsorshipId", sponsorship.getId());
                context.startActivity(intent);
                return;
            }
        }

    }
}
