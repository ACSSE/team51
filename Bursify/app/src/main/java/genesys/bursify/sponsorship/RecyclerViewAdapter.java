package genesys.bursify.sponsorship;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import genesys.bursify.R;

/**
 * Created by genesys on 2016/04/03.
 */
public class RecyclerViewAdapter extends RecyclerView.Adapter<RecyclerViewAdapter.ViewHolder>
{
    Context context;

    private ArrayList<Sponsorship> sponsorships;

    public RecyclerViewAdapter(ArrayList<Sponsorship> sponsorships)
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
        holder.txtSummary.setText(sponsorships.get(position).getDescription());

        holder.ratingBar.setRating((position % 5 == 0) ? 5 : position % 5);

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
        TextView textView;
        TextView txtSummary;
        CardView card;
        RatingBar ratingBar;

        public ViewHolder(View view)
        {
            super(view);

            textView = (TextView) view.findViewById(R.id.info_text);
            txtSummary = (TextView) view.findViewById(R.id.txtSummary);
            card = (CardView) view.findViewById(R.id.card_view);
            ratingBar = (RatingBar) view.findViewById(R.id.rating);
            ratingBar.setRating(5);
        }
    }

    private void viewSponsorship(String sponsorshipName)
    {
        Intent intent = new Intent(context, ViewSponsorshipActivity.class);

        int sponsorshipId;
        for (Sponsorship sponsorship : sponsorships)
        {
            if(sponsorship.getName().equalsIgnoreCase(sponsorshipName))
            {
                //sponsorshipId = ;
                intent.putExtra("sponsorshipId", sponsorship.getID());
                context.startActivity(intent);
                return;
            }
        }

    }
}
