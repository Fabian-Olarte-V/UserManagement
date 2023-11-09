import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserData } from 'src/app/models/user-data';
import { UserAccountService } from 'src/app/services/user-account.service';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.sass']
})
export class UserInfoComponent implements OnInit {

  UserData: UserData | undefined;

  constructor(private route: ActivatedRoute, private userService: UserAccountService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      let userId = params['id'];

      this.userService.getUserById(userId).subscribe(response => {
        this.UserData = new UserData('', '', response.name, response.lastName, response.numIdentification, response.email, response.identificationType);
        console.log(this.UserData)
      })
    })
  }
}
