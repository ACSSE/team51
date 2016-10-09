package genesys.bursify;

import android.app.Fragment;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;

import com.mikepenz.fontawesome_typeface_library.FontAwesome;
import com.mikepenz.iconics.IconicsDrawable;

import genesys.bursify.application.ApplicationFragment;
import genesys.bursify.reportcard.ReportCardFragment;
import genesys.bursify.utility.FragmentUtility;
import genesys.bursify.campaign.CampaignFragment;
import genesys.bursify.profile.ProfileActivity;
import genesys.bursify.sponsorship.SponsorshipFragment;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener
{
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
        if (drawer != null)
        {
            //drawer.setDrawerListener(toggle);
            drawer.addDrawerListener(toggle);
        }
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);


            Menu menu = navigationView.getMenu();

            setMenuIcons(menu);

            navigationView.setNavigationItemSelectedListener(this);


        if(getSupportActionBar() != null)
        {
            getSupportActionBar().setTitle("Sponsorships");
        }

        onNavigationItemSelected(navigationView.getMenu().getItem(0));
        navigationView.getMenu().getItem(0).setChecked(true);
    }

    private void setMenuIcons(Menu menu)
    {
        menu.findItem(R.id.nav_home).setIcon(new IconicsDrawable(this).icon(FontAwesome.Icon.faw_home).color(Color.DKGRAY));

        menu.findItem(R.id.nav_campaigns).setIcon(new IconicsDrawable(this).icon(FontAwesome.Icon.faw_user_plus).color(Color.DKGRAY));

        menu.findItem(R.id.nav_application).setIcon(new IconicsDrawable(this).icon(FontAwesome.Icon.faw_paperclip).color(Color.DKGRAY));

        menu.findItem(R.id.nav_report_card).setIcon(new IconicsDrawable(this).icon(FontAwesome.Icon.faw_university).color(Color.DKGRAY));

        menu.findItem(R.id.nav_profile).setIcon(new IconicsDrawable(this).icon(FontAwesome.Icon.faw_pencil_square_o).color(Color.DKGRAY));

        menu.findItem(R.id.nav_exit).setIcon(new IconicsDrawable(this).icon(FontAwesome.Icon.faw_power_off).color(Color.DKGRAY));
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

        if (id == R.id.nav_home)
        {
            //position = 1;
            fragmentUtility.loadFragment(SponsorshipFragment.newInstance(), SponsorshipFragment.class.getName(), R.id.homeContainer, fragmentManager);
            getSupportActionBar().setTitle("Sponsorships");
            //Toast.makeText(this, "Bursary", Toast.LENGTH_SHORT).show();
        }
        else if (id == R.id.nav_campaigns)
        {
            //position = 2;
            fragmentUtility.loadFragment(CampaignFragment.newInstance(), CampaignFragment.class.getName(), R.id.homeContainer, fragmentManager);
            getSupportActionBar().setTitle("Campaigns");
        }
        else if(id == R.id.nav_application)
        {

            fragmentUtility.loadFragment(ApplicationFragment.newInstance(), ApplicationFragment.class.getName(), R.id.homeContainer, fragmentManager);
            getSupportActionBar().setTitle("Applications");
        }
        else if (id == R.id.nav_report_card)
        {
            fragmentUtility.loadFragment(ReportCardFragment.newInstance(), ReportCardFragment.class.getName(), R.id.homeContainer, fragmentManager);
            getSupportActionBar().setTitle("Report Cards");
        }
        else if (id == R.id.nav_profile)
        {
            startActivity(new Intent(this, ProfileActivity.class));
        }
        /*else if (id == R.id.nav_exit)
        {

        }*/
        else if (id == R.id.nav_exit)
        {

        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer != null)
        {
            drawer.closeDrawer(GravityCompat.START);
        }
        return true;
    }
}
