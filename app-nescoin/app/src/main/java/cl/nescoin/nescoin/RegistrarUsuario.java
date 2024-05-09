package cl.nescoin.nescoin;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import cl.nescoin.nescoin.models.Globales;

public class RegistrarUsuario extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registrar_usuario);
        setTitle("Registrar Usuario");

    }

    public void registrausuario(View view){
        EditText et_nom = (EditText)findViewById(R.id.edt_registro_nombre);
        EditText et_ape = (EditText)findViewById(R.id.edt_registro_apellido);
        EditText et_des = (EditText)findViewById(R.id.edt_registro_descripcion);
        EditText et_tel = (EditText)findViewById(R.id.edt_registro_telefono);
        EditText et_cor = (EditText)findViewById(R.id.edt_registro_correo);
        EditText et_pas = (EditText)findViewById(R.id.edt_registro_password);

        String nom = et_nom.getText().toString();
        String ape = et_ape.getText().toString();
        String des = et_des.getText().toString();
        String tel = et_tel.getText().toString();
        String cor = et_cor.getText().toString();
        String pas = et_pas.getText().toString();

        if(!nom.equals("") & !ape.equals("") & !des.equals("") &
                !tel.equals("") & !cor.equals("") & !pas.equals("")){

            //String _nick = cor.substring(0, cor.indexOf("@"));
            // se evalua registro
            registrausuarionuevo(nom, ape, des, tel, cor, pas);

        }else{
            Toast.makeText(this,"Para registrar, debe completar todos los campos",Toast.LENGTH_SHORT).show();
        }
    }

/*

    private void evaluaregistrorusuario(String nom, String ape, String des,
                                        String tel, String cor, String pass){

        String URL_consulta ="http://"+ Global.miIP+"/webnescoin/login/datosUsuario?nick="+cor+"&contraseña="+pass;
        JsonArrayRequest request;
        RequestQueue requestQueue;
        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest
                (Request.Method.GET, URL_consulta, null, new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                            // el usuario existe por lo que no se puiede volver a registrar
                            Toast.makeText(getApplicationContext(), "Error! usuario:"+cor+ " ya esta registrado", Toast.LENGTH_LONG).show();
                    }
                }, new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        registrausuarionuevo(nom, ape, des, tel, cor, pass);
                        error.printStackTrace();
                        Toast.makeText(getApplicationContext(), "usuario no existe, puede registrar ", Toast.LENGTH_LONG).show();

                    }
                });

        requestQueue = Volley.newRequestQueue(this);
        requestQueue.add(jsonObjectRequest);

    }
*/


    private void registrausuarionuevo(String nom, String ape, String des,
                                      String tel, String cor, String pass){
        //grabamos el usuario
        // LLAMA API
        pass = hashClave(pass);
        String URL_consulta ="http://"+ Globales.miIP+"/webnescoin/registro/rUsuario1?nombre="+nom+"&apellido="+ape+
                "&descripcion="+des+"&telefono="+tel+"&email="+cor+"&password_1="+pass;
        JsonArrayRequest request;
        RequestQueue requestQueue;
        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest
                (Request.Method.POST, URL_consulta, null, new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        // REGISTRO NUEVO USUARIO
                        Toast.makeText(getApplicationContext(), " OK! REGISTRO EXITOSO", Toast.LENGTH_LONG).show();
                    }
                }, new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        error.printStackTrace();
                        // FALLA REGISTRO
                        Toast.makeText(getApplicationContext(), "ERROR! NO SE PUDO REGISTRAR USUARIO ", Toast.LENGTH_LONG).show();


                    }
                });

        requestQueue = Volley.newRequestQueue(this);
        requestQueue.add(jsonObjectRequest);

    }

    private String hashClave(String clave) {
        try { java.security.MessageDigest md = java.security.MessageDigest.getInstance("md5");
            byte[] array = md.digest(clave.getBytes());
            StringBuffer sb = new StringBuffer();
            for (int i = 0; i < array.length; ++i) {
                sb.append(Integer.toHexString((array[i] & 0xFF) | 0x100).substring(1,3));
            }
            return sb.toString();
        } catch (java.security.NoSuchAlgorithmException e) {

        }
        return null;
    }

}