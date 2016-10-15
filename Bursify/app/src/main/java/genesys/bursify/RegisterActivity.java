package genesys.bursify;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;

import org.json.JSONException;
import org.json.JSONObject;

import genesys.bursify.utility.BursifyService;

public class RegisterActivity extends AppCompatActivity
{
    private UserRegisterTask mAuthTask = null;
    private EditText mPasswordView, mEmailView, mNameView;
    private ProgressBar mProgressView;
    private Button mRegisterButton;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_register);

        mProgressView = (ProgressBar) findViewById(R.id.register_progress);

        mNameView = (EditText) findViewById(R.id.name);
        mEmailView = (EditText) findViewById(R.id.email);
        mPasswordView = (EditText) findViewById(R.id.password);

        mRegisterButton = (Button) findViewById(R.id.btn_register);

        mRegisterButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                attemptRegistration();
            }
        });
    }

    private void attemptRegistration()
    {
        if (mAuthTask != null)
        {
            return;
        }

        // Reset errors.
        mEmailView.setError(null);
        mPasswordView.setError(null);

        // Store values at the time of the login attempt.
        String name = mNameView.getText().toString();
        String email = mEmailView.getText().toString();
        String password = mPasswordView.getText().toString();

        boolean cancel = false;
        View focusView = null;

        // Check for a valid password, if the user entered one.
        if (!TextUtils.isEmpty(password) && !isPasswordValid(password))
        {
            mPasswordView.setError(getString(R.string.error_invalid_password));
            focusView = mPasswordView;
            cancel = true;
        }

        // Check for a valid email address.
        if (TextUtils.isEmpty(email))
        {
            mEmailView.setError(getString(R.string.error_field_required));
            focusView = mEmailView;
            cancel = true;
        }
        else if (!isEmailValid(email))
        {
            mEmailView.setError(getString(R.string.error_invalid_email));
            focusView = mEmailView;
            cancel = true;
        }

        if (cancel)
        {
            // There was an error; don't attempt login and focus the first
            // form field with an error.
            focusView.requestFocus();
        }
        else
        {
            // Show a progress spinner, and kick off a background task to
            // perform the user login attempt.
            mProgressView.setVisibility(View.VISIBLE);
            mAuthTask = new UserRegisterTask(name, email, password);
            mAuthTask.execute((Void) null);
        }
    }

    private boolean isEmailValid(String email)
    {
        //TODO: Replace this with your own logic
        return email.contains("@");
    }

    private boolean isPasswordValid(String password)
    {
        //TODO: Replace this with your own logic
        return password.length() > 4;
    }


    class UserRegisterTask extends AsyncTask<Void, Void, Boolean>
    {
        private final String mName;
        private final String mEmail;
        private final String mPassword;

        UserRegisterTask(String name, String email, String password)
        {
            mName = name;
            mEmail = email;
            mPassword = password;
        }

        @Override
        protected Boolean doInBackground(Void... params)
        {
            JSONObject registerObject = new JSONObject();
            JSONObject response;

            try
            {
                registerObject.accumulate("Username", mName);
                registerObject.accumulate("Password", mPassword);
                registerObject.accumulate("UserEmail", mEmail);
                registerObject.accumulate("UserType", "Student");

                response = BursifyService.postService(BursifyService.REGISTER, registerObject);

                return response.getBoolean("success");
            }
            catch (JSONException e)
            {
                e.printStackTrace();
            }

            // TODO: register the new account here.
            return false;
        }

        @Override
        protected void onProgressUpdate(Void... values)
        {
            super.onProgressUpdate(values);

            mProgressView.setVisibility(View.VISIBLE);
        }

        @Override
        protected void onPostExecute(final Boolean success)
        {
            mAuthTask = null;
            mProgressView.setVisibility(View.GONE);

            if (success)
            {
                startActivity(new Intent(RegisterActivity.this, MainActivity.class));
            }
            else
            {
                mPasswordView.setError(getString(R.string.error_incorrect_password));
                mPasswordView.requestFocus();
            }
        }

        @Override
        protected void onCancelled()
        {
            mAuthTask = null;
           mProgressView.setVisibility(View.GONE);
        }
    }
}
