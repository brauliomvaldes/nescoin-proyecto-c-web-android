package cl.nescoin.nescoin;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.util.JsonToken;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.Toolbar;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import cl.nescoin.nescoin.models.ExampleDialog;
import cl.nescoin.nescoin.models.Globales;
import cl.nescoin.nescoin.models.MListaContacto;

public class MainActivity extends AppCompatActivity implements ExampleDialog.ExampleDialogListener {

    private TextView textViewClave;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        textViewClave = (TextView) findViewById(R.id.textview_clave);
        Button btn = (Button) findViewById(R.id.btn_login);

        //listener onclick para registrar usuario
        TextView txtRegistrar = (TextView) findViewById(R.id.txtRegistrar);
        txtRegistrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(v.getContext(), RegistrarUsuario.class);
                startActivity(intent);
            }
        });

        //listener onclick para recuperar contraseña
        TextView txtRecuperaClave = (TextView) findViewById(R.id.txtRecuperaClave);
        txtRecuperaClave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // llama a dialogo
                openDialog();
            }
        });
    }

    @Override
    protected void onResume() {
        super.onResume();
        if (!(Globales.getId()==null)) {
            Intent intent = new Intent(getApplicationContext(), ListaContactos.class);
            intent.putExtra("id", Globales.getId());
            intent.putExtra("nombre", Globales.getNombre());
            intent.putExtra("apellido", Globales.getApellido());
            startActivity(intent);
        }
        EditText edtlogin = (EditText) findViewById(R.id.edt_login_nick);
        EditText edtclave = (EditText) findViewById(R.id.edt_login_password);

        if (!(edtclave.getText().toString().isEmpty()) && !(edtlogin.getText().toString().isEmpty())){
            edtlogin.setText("");
            edtclave.setText("");
        }
    }


    public void openDialog() {
        ExampleDialog exampleDialog = new ExampleDialog();
        exampleDialog.show(getSupportFragmentManager(), "mensaje");
    }


    public void applyTexts(String clave) {
        Toast.makeText(this, "Se enviará su nueva CONTRASEÑA al correo:"+clave, Toast.LENGTH_LONG).show();
    }

    @RequiresApi(api = Build.VERSION_CODES.M)
    public void chequealogin(View view){

        // para cerra teclado al hacer click
        try {
            View v = this.getCurrentFocus();
            v.clearFocus();
            if (v != null) {
                InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
                imm.hideSoftInputFromWindow(v.getWindowToken(), 0);
            }
        }catch (Exception e){}

        //

        EditText edtlogin = (EditText) findViewById(R.id.edt_login_nick);
        EditText edtclave = (EditText) findViewById(R.id.edt_login_password);
        String nick = edtlogin.getText().toString();
        String pass = edtclave.getText().toString();
        if(nick!="" && pass!=""){
            String URL ="http://"+ Globales.miIP+"/webnescoin/login/datosUsuario?nick="+nick+"&contraseña="+pass;
            JsonArrayRequest request;
            RequestQueue requestQueue;
            JsonObjectRequest jsonObjectRequest = new JsonObjectRequest
                    (Request.Method.POST, URL, null, new Response.Listener<JSONObject>() {
                        @Override
                        public void onResponse(JSONObject response) {

                        JSONObject jsonObject = null;
                            try {
                                Intent intent = new Intent(getApplicationContext(),ListaContactos.class);

                                Globales.setId(response.getString("id_usuario"));
                                Globales.setNombre(response.getString("nombre"));
                                Globales.setApellido(response.getString("apellido"));

                                intent.putExtra("id", response.getString("id_usuario"));
                                intent.putExtra("nombre", response.getString("nombre"));
                                intent.putExtra("apellido", response.getString("apellido"));
                                Globales.setId(response.getString("id_usuario"));
                                //Toast.makeText(getApplicationContext(), "id:"+response.getString("id_usuario"), Toast.LENGTH_LONG).show();
                                startActivity(intent);
                            } catch (JSONException e) {
                                e.printStackTrace();
                                Toast.makeText(getApplicationContext(), "error de lectura", Toast.LENGTH_LONG).show();
                            }
                }
            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {
                    error.printStackTrace();
                    Toast.makeText(getApplicationContext(), "usuario o password incorrectos", Toast.LENGTH_LONG).show();
                }
            });

            requestQueue = Volley.newRequestQueue(this);
            requestQueue.add(jsonObjectRequest);

        }else{
            Toast.makeText(getApplicationContext(), "Debe indicar una usuario y password", Toast.LENGTH_LONG).show();
        }
    }
}