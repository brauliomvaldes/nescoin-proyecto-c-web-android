package cl.nescoin.nescoin;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

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

import java.util.ArrayList;
import java.util.List;

import cl.nescoin.nescoin.models.Globales;
import cl.nescoin.nescoin.models.MListaContacto;
import cl.nescoin.nescoin.models.MListaPublicaciones;

public class Publicaciones extends AppCompatActivity {

    private JsonArrayRequest request;
    private List<MListaPublicaciones> listaPublicaciones;
    private RequestQueue requestQueue;
    TextView txtNombreUsuario;
    private String URL  = "http://"+ Globales.miIP+"/webnescoin/oferta/datosPublicacion?id=";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_publicaciones);

        String id_usuario="";
        String nombre ="";
        String apellido ="";
        // recuperar id usuario
        Bundle idusuario = getIntent().getExtras();
        if(idusuario!=null){
            id_usuario=idusuario.getString("id");
            nombre = idusuario.getString("nombre");
            apellido = idusuario.getString("apellido");
            URL=URL+id_usuario;
            evaluaregistropublicacionesdelusuario();

            txtNombreUsuario = (TextView) findViewById(R.id.txtNombreUsuario);
            txtNombreUsuario.setText(" Proyectos de: "+ nombre + " " + apellido );
        }else{
            Toast.makeText(getApplicationContext(), "No hay datos!!!", Toast.LENGTH_SHORT).show();
        }
    }

    private void evaluaregistropublicacionesdelusuario(){
        //Toast.makeText(getApplicationContext(), "url:"+URL, Toast.LENGTH_LONG).show();

        request = new JsonArrayRequest(URL, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                JSONObject jsonObject = null;
                String publicacionesArray[]=new String[response.length()];
                //Toast.makeText(getApplicationContext(), "largo:"+response.length(), Toast.LENGTH_LONG).show();
                int p=0;
                if(response.length()==0){
                    Toast.makeText(getApplicationContext(), "No cuenta con publicaciones registradas que mostrar", Toast.LENGTH_LONG).show();
                }
                for (int i = 0; i < response.length(); i++) {
                    p++;
                    try {
                        //Toast.makeText(getApplicationContext(), "dato:"+response.getJSONObject(i), Toast.LENGTH_LONG).show();
                        jsonObject = response.getJSONObject(i);

                        publicacionesArray[i]="Publicación Nº"+p
                                +" Título: "+jsonObject.getString("Titulo")
                                +", detalle: "+jsonObject.getString("descripcion");

                    } catch (JSONException e) {
                        e.printStackTrace();
                        Toast.makeText(getApplicationContext(), "error e:"+e, Toast.LENGTH_LONG).show();
                    }
                }
                despliega(publicacionesArray);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                //error.printStackTrace();
                Toast.makeText(getApplicationContext(), "No cuenta con publicaciones registradas que mostrar", Toast.LENGTH_LONG).show();
            }
        });

        requestQueue = Volley.newRequestQueue(this);
        requestQueue.add(request);
    }

    public void despliega(String[] publicaciones) {
        final ListView lista = (ListView)findViewById(R.id.ListView_lista);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>
                (this, android.R.layout.simple_list_item_1, publicaciones){
            // solo para cambiar color de fondo del list view por cada item almacenado
            @NonNull
            @Override
            public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
                // lee caeda item de la list view
                View view = super.getView(position, convertView, parent);
                // setear color 1
                if(position % 2 == 1){
                    view.setBackgroundColor(getResources().getColor(android.R.color.holo_green_light));
                }else{
                    view.setBackgroundColor(getResources().getColor(android.R.color.holo_orange_light));
                }
                  return view;
            };
        };
        lista.setAdapter(adapter);
        // accion sobre click en la lista

    }

}