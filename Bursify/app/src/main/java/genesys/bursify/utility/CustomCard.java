package genesys.bursify.utility;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import genesys.bursify.R;
import it.gmariotti.cardslib.library.internal.Card;
import retrofit2.Call;

/**
 * Created by Brandon on 2016/09/23.
 */
public class CustomCard extends Card
{
    private TextView txtTitle;
    private ImageView stateImg;
    private String title;

    public CustomCard(Context context, int innerLayout, String title)
    {
        super(context, innerLayout);
        this.title = title;
    }

    @Override
    public void setupInnerViewElements(ViewGroup parent, View view)
    {
        super.setupInnerViewElements(parent, view);

        txtTitle = (TextView) parent.findViewById(R.id.cardText);
        stateImg = (ImageView) parent.findViewById(R.id.cardImage);

        txtTitle.setText(title);

        if(isExpanded())
        {
            stateImg.setImageResource(R.drawable.ic_expand_less);
        }
        else
        {
            stateImg.setImageResource(R.drawable.ic_expand_more);
        }

    }

}
