package genesys.bursify.application;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.ArrayList;

import genesys.bursify.R;
import genesys.bursify.data.entities.Application;
import genesys.bursify.data.models.ApplicationResponse;

public class ApplicationRecyclerViewAdapter extends RecyclerView.Adapter<ApplicationRecyclerViewAdapter.ViewHolder>
{
    private Context context;
    private ArrayList<Application> applications;
    private String[] apps = {"app1", "app2", "app3", "app4", "app5"};

    public ApplicationRecyclerViewAdapter(ArrayList<Application> applications)
    {
        this.applications = applications;
    }

    public ApplicationRecyclerViewAdapter()
    {
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType)
    {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.application_card, parent, false);
        context = parent.getContext();

        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position)
    {
        holder.textView.setText(applications.get(position).getSponsorshipName());
    }

    @Override
    public int getItemCount()
    {
        return applications.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder
    {
        TextView textView;

        public ViewHolder(View view)
        {
            super(view);

            textView = (TextView) view.findViewById(R.id.applicationTitle);
        }
    }
}
