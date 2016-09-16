package genesys.bursify;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;

import genesys.bursify.utility.FragmentUtility;
import genesys.bursify.campaign.CampaignFragment;
import genesys.bursify.profile.ProfileActivity;
import genesys.bursify.sponsorship.SponsorshipFragment;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener
{

    int position = 1;
    FragmentManager fragmentManager;
    FragmentUtility fragmentUtility = new FragmentUtility();

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

       fragmentManager = getSupportFragmentManager();

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        getSupportActionBar().setTitle("Sponsorships");

        setFragment();
    }



    private void setFragment()
    {
        switch(position)
        {
            case 1:
                fragmentUtility.loadFragment(SponsorshipFragment.newInstance(), SponsorshipFragment.class.getName(), R.id.homeContainer, fragmentManager);
                break;

            case 2:
                fragmentUtility.loadFragment(CampaignFragment.newInstance(), CampaignFragment.class.getName(), R.id.homeContainer, fragmentManager);
                break;
        }
    }

    @Override
    public void onBackPressed()
    {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START))
        {
            drawer.closeDrawer(GravityCompat.START);
        }
        else
        {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings)
        {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item)
    {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.nav_camera)
        {
            //position = 1;
            fragmentUtility.loadFragment(SponsorshipFragment.newInstance(), SponsorshipFragment.class.getName(), R.id.homeContainer, fragmentManager);
            getSupportActionBar().setTitle("Sponsorships");
            //Toast.makeText(this, "Bursary", Toast.LENGTH_SHORT).show();
        }
        else if (id == R.id.nav_gallery)
        {
            //position = 2;
            fragmentUtility.loadFragment(CampaignFragment.newInstance(), CampaignFragment.class.getName(), R.id.homeContainer, fragmentManager);
            getSupportActionBar().setTitle("Campaigns");
        }
        else if (id == R.id.nav_slideshow)
        {
            startActivity(new Intent(this, ProfileActivity.class));
        }
        /*else if (id == R.id.nav_manage)
        {

        }
        else if (id == R.id.nav_share)
        {

        }*/
        else if (id == R.id.nav_send)
        {

        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
}
