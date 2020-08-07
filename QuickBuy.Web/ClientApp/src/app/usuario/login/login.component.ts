import { Component } from "@angular/core"; 
import { Usuario } from "../../modelo/usuario";


@Component({
  selector: "app-login", 
  templateUrl: './login.component.html',
  styleUrls: ["./login.component.css"] 
})
export class LoginComponent {

    public usuario;
    public usuarioAutenticado: boolean;
    public email
  

 constructor()
    {
        this.usuario = new Usuario();
    }


entrar()
  {
    if (this.usuario.email == "bruno@teste.com" && this.usuario.senha == "123")
      {
        this.usuarioAutenticado = true;
      }
  }

 


}
