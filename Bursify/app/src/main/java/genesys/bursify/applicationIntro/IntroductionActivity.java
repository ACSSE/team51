package genesys.bursify.applicationIntro;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;

import com.github.paolorotolo.appintro.AppIntro;
import com.github.paolorotolo.appintro.AppIntro2;

import genesys.bursify.LoginActivity;
import genesys.bursify.R;

public class IntroductionActivity extends AppIntro2
{


    @Override
    public void init(@Nullable Bundle savedInstanceState)
    {
        addSlide(new FirstIntroductionFragment());
        addSlide(new SecondIntroductionFragment());
        addSlide(new ThirdIntroductionFragment());


        setProgressButtonEnabled(true);
        showStatusBar(true);
    }


    @Override
    public void onNextPressed()
    {

    }

    @Override
    public void onDonePressed()
    {
        startActivity(new Intent(this, LoginActivity.class));
    }

    @Override
    public void onSlideChanged()
    {

    }
}
