import { Component, OnInit } from "@angular/core";
import { Product } from "../../models/product";
import { NgFor } from "@angular/common";
import { ProductFilter } from "../../models/productFilter";
import { FormsModule } from "@angular/forms";
import { Router, RouterModule } from "@angular/router";
import { VotingService } from "../services/voting.service";
import { HttpClient, HttpClientModule, HttpHandler } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";

@Component({
    selector: 'voting-list',
    standalone: true,
    imports: [NgFor, FormsModule, RouterModule ],
    providers: [HttpClientModule],
    templateUrl: './voting-list.component.html',
    styleUrls: ['./voting-list.component.scss']
  })
  export class VotingListComponent implements OnInit {
    constructor(private router: Router, private votingService: VotingService) {}

    ngOnInit(): void {
    }

    votingList = [
      { name: 'Jan Kowalski', voted: false },
      { name: 'Anna Nowak', voted: true },
      { name: 'Piotr Wiśniewski', voted: false }
    ];

    voteSummary = [
      { name: 'Jan Kowalski', votes: 10 },
      { name: 'Anna Nowak', votes: 15 },
      { name: 'Piotr Wiśniewski', votes: 7 }
    ];
  
    selectedOption1 = '';
    selectedOption2 = '';
  
    submitForm() {
    }
  }
  