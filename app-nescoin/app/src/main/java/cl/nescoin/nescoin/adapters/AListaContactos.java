package cl.nescoin.nescoin.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.RatingBar;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import cl.nescoin.nescoin.models.MListaContacto;
import cl.nescoin.nescoin.R;

// a la clase se implementa la interface onclicklistener porque no viene incluido
public class AListaContactos extends RecyclerView.Adapter<AListaContactos.ViewHolder> implements View.OnClickListener{

    private List<MListaContacto> listaContacto;
    private Context context;
    private View.OnClickListener listener;
    //
    public AListaContactos(List<MListaContacto> listaContacto, Context context){
        this.listaContacto = listaContacto;
        this.context = context;
    }

    //permite enlazar el layout de elementos de la lista contacto
    @Override
    public ViewHolder onCreateViewHolder( ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.elementos_lista_contactos,parent,false);
        //activa el listener onclick
        v.setOnClickListener(this);
        return new ViewHolder(v);
    }

    //Enlaza los datos de acuerdo al modelo de MListaContacto
    @Override
    public void onBindViewHolder( final ViewHolder viewHolder, int position) {
        final MListaContacto listaItem = listaContacto.get(position);

        viewHolder.txtNombre.setText(listaItem.getNombre());
        viewHolder.txtApellido.setText(listaItem.getApellido());
        viewHolder.txtNumeroTelefono.setText(String.valueOf(listaItem.getNumeroTelefono()));
        viewHolder.txtProfesion.setText(listaItem.getProfesion());
        viewHolder.rbEvaluacion.setRating(listaItem.getRating());
    }

    //Cuenta la cantidad de elemento que existe en el objeto listaContacto
    @Override
    public int getItemCount() {
        return listaContacto.size();
    }

    // se inicializa el escuchador
    public void setOnClickListener(View.OnClickListener listener){
        this.listener=listener;
    }

    // se implementa y sobreescribe metodo del onclicklistener
    @Override
    public void onClick(View v) {
        if (listener!=null){
            listener.onClick(v);
        }
    }

    //Se enlaza los campos de la vista con sus variables.
    public class ViewHolder extends RecyclerView.ViewHolder{

        private TextView txtNombre, txtApellido,txtProfesion,txtNumeroTelefono;
        private RatingBar rbEvaluacion;

        public LinearLayout linearLayout;

        public ViewHolder( View itemView) {
            super(itemView);

            txtNombre = (TextView) itemView.findViewById(R.id.tvNombre);
            txtApellido = (TextView) itemView.findViewById(R.id.tvApellido);
            txtProfesion = (TextView) itemView.findViewById(R.id.tvProfesion);
            txtNumeroTelefono = (TextView) itemView.findViewById(R.id.tvTelefono);
            rbEvaluacion = (RatingBar) itemView.findViewById(R.id.rbEvaluacion);
            linearLayout = (LinearLayout) itemView.findViewById(R.id.lyListacontacto);
        }
    }
}
