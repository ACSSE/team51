package genesys.bursify.campaign;

import android.content.Context;
import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import genesys.bursify.R;


/**
 * Created by Brandon on 2016/04/27.
 */
public class CampaignRecyclerViewAdapter extends RecyclerView.Adapter<CampaignRecyclerViewAdapter.ViewHolder>
{
    private String[] dataSet = {"Sky Soccer", "Rugby Stars", "Whirlpool Cricket", "Milky Way Theatre", "Orion Kickers", "Kepler Beam", "Pluto Ascend", "Moon Readers", "Vulcan Order", "Kronos Reach"};
    private String summaryText = " has sponsored between 50 and 80 candidates each year for the last five years in a wide range of financial fields and will keep doing so with their bursary program.";
    Context context;

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType)
    {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.campaign_card_view, parent, false);
        context = parent.getContext();

        //TextView txt = (TextView) view.findViewById(R.id.info_text);

        ViewHolder holder = new ViewHolder(view);

        return holder;
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, final int position)
    {
        holder.textView.setText(dataSet[position]);
        holder.txtSummary.setText(dataSet[position] + summaryText);

        holder.progressBar.setProgress((position % 5 == 0) ? 5 : position % 5);

        holder.card.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Toast.makeText(context, "Item " + position, Toast.LENGTH_SHORT).show();

            }
        });
    }


    @Override
    public int getItemCount()
    {
        return dataSet.length;
    }

    public static class ViewHolder extends RecyclerView.ViewHolder
    {
        TextView textView;
        TextView txtSummary;
        CardView card;
        ProgressBar progressBar;

        public ViewHolder(View view) {
            super(view);

            textView = (TextView) view.findViewById(R.id.info_text);
            txtSummary = (TextView) view.findViewById(R.id.txtCampaignSummary);
            card = (CardView) view.findViewById(R.id.card_view);
            progressBar = (ProgressBar) view.findViewById(R.id.campaignProgress);
            progressBar.setMax(5);
        }
    }
}
