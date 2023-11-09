import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserData } from 'src/app/models/user-data';
import { UserAccountService } from 'src/app/services/user-account.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.sass']
})
export class RegisterUserComponent {

  registerForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private userService: UserAccountService, private router: Router) {
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
      lastname: ['', Validators.required],
      identification: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      identificationType: ['', Validators.required]
    });
  }

  onSubmit(){
    if(this.registerForm.valid){
      this.userService.registerUserAccount(
        new UserData(this.registerForm.get("username")?.value, this.registerForm.get("password")?.value, this.registerForm.get("name")?.value,
                     this.registerForm.get("lastname")?.value, this.registerForm.get("identification")?.value, this.registerForm.get("email")?.value, 
                     this.registerForm.get("identificationType")?.value))
        .subscribe(response => {
            if(response.id != undefined){
              this.router.navigate(['/user', response.id]);
            } 
        })
    }
  }
}
