package genesys.bursify;

import android.content.Context;
import android.support.v7.widget.CardView;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

/**
 * Created by genesys on 2016/04/03.
 */
public class RecyclerViewAdapter extends RecyclerView.Adapter<RecyclerViewAdapter.ViewHolder>
{
    private String[] dataSet = {"Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 10"};
    Context context;

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.card_view, parent, false);
        context = parent.getContext();

        //TextView txt = (TextView) view.findViewById(R.id.info_text);

        ViewHolder holder = new ViewHolder(view);

        return holder;
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, final int position) {

        holder.textView.setText(dataSet[position]);

        holder.ratingBar.setRating(position % 5);

        holder.card.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Toast.makeText(context, "Item " + position, Toast.LENGTH_SHORT).show();

            }
        });
        //holder.card.setCardBackgroundColor(Color.CYAN);

    }

    @Override
    public int getItemCount() {
        return dataSet.length;
    }

    public static class ViewHolder extends RecyclerView.ViewHolder
    {
        TextView textView;
        CardView card;
        RatingBar ratingBar;
        public ViewHolder(View view) {
            super(view);

            textView = (TextView) view.findViewById(R.id.info_text);
            card = (CardView) view.findViewById(R.id.card_view);
            ratingBar = (RatingBar) view.findViewById(R.id.rating);
            ratingBar.setRating(5);
        }
    }
}
