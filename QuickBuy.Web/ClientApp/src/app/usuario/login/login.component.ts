import { Component } from "@angular/core"; 


@Component({
  selector: "app-login", 
  templateUrl: './login.component.html',
  styleUrls: ["./login.component.css"] 
})
export class LoginComponent {

  public email = "bruno@teste.com";


  entrar() {
    alert('entrar no sistema');
  }

}
