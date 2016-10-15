package genesys.bursify.reportcard;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import genesys.bursify.R;


public class ReportRecyclerViewAdapter extends RecyclerView.Adapter<ReportRecyclerViewAdapter.ViewHolder> implements View.OnClickListener
{
    Context context;
    private String[] apps = {"app1", "app2", "app3", "app4", "app5"};

    @Override
    public ReportRecyclerViewAdapter.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType)
    {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.report_card_view, parent, false);
        context = parent.getContext();

        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(ReportRecyclerViewAdapter.ViewHolder holder, int position)
    {
        holder.schoolName.setText(apps[position]);
    }

    @Override
    public int getItemCount()
    {
        return apps.length;
    }

    @Override
    public void onClick(View v)
    {

    }


    class ViewHolder extends RecyclerView.ViewHolder
    {
        TextView schoolName;

        public ViewHolder(View view)
        {
            super(view);

            schoolName = (TextView) view.findViewById(R.id.school_name);
        }
    }
}
