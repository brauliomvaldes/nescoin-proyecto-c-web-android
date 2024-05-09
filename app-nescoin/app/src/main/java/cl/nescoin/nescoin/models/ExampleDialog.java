package cl.nescoin.nescoin.models;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;

import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;

import androidx.appcompat.app.AppCompatDialogFragment;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import cl.nescoin.nescoin.R;

public class ExampleDialog extends AppCompatDialogFragment {
    private EditText editTextClave;
    private ExampleDialogListener listener;
    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        LayoutInflater inflater = getActivity().getLayoutInflater();
        View view = inflater.inflate(R.layout.layout_dialog, null);
        builder.setView(view)
                .setTitle("Recuperación de Contraseña")
                .setNegativeButton("cancelar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                    }
                })
                .setPositiveButton("confirmar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        String clave = editTextClave.getText().toString();
                        listener.applyTexts(clave);
                        if(clave != null && clave != ""){
                            getPassword(clave);
                        }
                    }
                });
        editTextClave = view.findViewById(R.id.edit_clave);
        return builder.create();
    }
    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        try {
            listener = (ExampleDialogListener) context;
        } catch (ClassCastException e) {
            throw new ClassCastException(context.toString() +
                    "must implement ExampleDialogListener");
        }
    }
    public interface ExampleDialogListener {
        void applyTexts(String clave);
    }

    //Envia la solicitud de recuperación de contraseña
    public void getPassword(String correo){

        //String url = "http://192.168.1.46/webnescoin/recupera/recuperaclaveapi?correo=" + correo;
        RequestQueue colaPeticiones = Volley.newRequestQueue(getContext());
        StringRequest peticion = new StringRequest(
                Request.Method.POST,
                "http://192.168.1.46/webnescoin/recupera/apiRecuperaClave?correo=" + correo,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String respuesta) {
                        //Toast.makeText(getContext(), "Resultado: "+ respuesta, Toast.LENGTH_LONG).show();
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                    }
                }
        );
        colaPeticiones.add(peticion);
    }

}