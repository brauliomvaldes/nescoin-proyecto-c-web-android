package cl.nescoin.nescoin;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONObject;

import cl.nescoin.nescoin.models.Globales;

public class AgregarNuevoContacto extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_agregar_nuevo_contacto);
        setTitle("Agregar Nuevo Contacto");
    }
    public void registracontacto(View view){
        EditText et_nom = (EditText)findViewById(R.id.edt_registro_nombre_contacto);
        EditText et_ape = (EditText)findViewById(R.id.edt_registro_apellido_contacto);
        EditText et_des = (EditText)findViewById(R.id.edt_registro_descripcion_contacto);
        EditText et_tel = (EditText)findViewById(R.id.edt_registro_telefono_contacto);
        EditText et_cor = (EditText)findViewById(R.id.edt_registro_correo_contacto);

        String nom = et_nom.getText().toString();
        String ape = et_ape.getText().toString();
        String des = et_des.getText().toString();
        String tel = et_tel.getText().toString();
        String cor = et_cor.getText().toString();

        if(tel.length()!=9){
            Toast.makeText(getApplicationContext(), " Se esperan 9 dígitos en teléfono, reintente nuevamente ", Toast.LENGTH_LONG).show();
        }else {
            if (!nom.equals("") & !ape.equals("") & !des.equals("") & !cor.equals("")) {

                // se agrega nuevo contacto
                // LLAMA API para registrar contacto
                // debe existir el API

                String URL_consulta = "http://" + Globales.miIP + "/webnescoin/registrocontacto/guardacontactoapp?idusuarioapp=" + Globales.getId() +
                        "&nombre=" + nom + "&apellido=" + ape + "&actividad=" + des + "&correo=" + cor + "&telefono=" + tel;

                //Toast.makeText(getApplicationContext(), " url: "+URL_consulta, Toast.LENGTH_LONG).show();

                JsonArrayRequest request;
                RequestQueue requestQueue;

                JsonObjectRequest jsonObjectRequest = new JsonObjectRequest
                        (Request.Method.POST, URL_consulta, null, new Response.Listener<JSONObject>() {
                            @Override
                            public void onResponse(JSONObject response) {
                                // REGISTRO NUEVO USUARIO

                                Toast.makeText(getApplicationContext(), response.toString(), Toast.LENGTH_LONG).show();

                            }
                        }, new Response.ErrorListener() {
                            @Override
                            public void onErrorResponse(VolleyError error) {
                                //error.printStackTrace();
                                // FALLA CONEXION
                                Toast.makeText(getApplicationContext(), "ERROR! "+error, Toast.LENGTH_LONG).show();

                            }
                        });
                // configura tiempo de reintento en la publicacion de la informacion al servidor
                // para evitar doble publicacion por el reintento
                // esto hace con no se realicen reintentos

                jsonObjectRequest.setRetryPolicy(new DefaultRetryPolicy( 0, -1,
                        DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));

                //

                requestQueue = Volley.newRequestQueue(this);
                
                requestQueue.add(jsonObjectRequest);
                // limpia campos
                et_nom.setText("");
                et_ape.setText("");
                et_des.setText("");
                et_tel.setText("");
                et_cor.setText("");
            } else {
                Toast.makeText(this, "Para agregar, debe completar todos los campos", Toast.LENGTH_SHORT).show();
            }
        }
    }

}