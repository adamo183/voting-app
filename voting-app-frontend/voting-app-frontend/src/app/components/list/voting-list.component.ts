import { Component, OnInit } from "@angular/core";
import { NgFor } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { Router, RouterModule } from "@angular/router";
import { VotingService } from "../services/voting.service";
import { HttpClient, HttpClientModule, HttpHandler } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { map, Observable } from "rxjs";
import { Voter } from "src/app/models/voter";
import { Candidate } from "src/app/models/candidate";
import { CandidateAddModel } from "src/app/models/candidateAddModel";
import { VoterAddModel } from "src/app/models/voterAddModel";
import { VoteModel } from "src/app/models/voteModel";

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
    public newVoterName: string = '';
    public newCandidateName: string = '';
    public votingList: Array<Voter> = [];
    public enableVoters: Array<Voter> = [];
    public candidateList: Array<Candidate> = [];
    public selectedVoter = 0;
    public selectedCandidate = 0;

    ngOnInit(): void {
      this.getVoters();
      this.getCandidates();
    }

    getVoters(){
      this.votingService.getVoters().subscribe(
        (res) => {
            this.enableVoters = res.filter(x => x.hasVoted == false);
            this.votingList = res;
            return;
        });
    }

    getCandidates(){
      this.votingService.getCandidates().subscribe(
        (res) => {
            return this.candidateList = res;
        });
    }

    submitForm() {
      if (this.selectedCandidate && this.selectedVoter)
      {
        const newModel: VoteModel = new VoteModel();
        newModel.candidateId = this.selectedCandidate
        newModel.voterId = this.selectedVoter
        this.votingService.postNewVote(newModel).subscribe(
          (x) => { 
            this.getCandidates(); 
            this.getVoters();
            this.selectedCandidate = 0;
            this.selectedVoter = 0;
          });
      }
    }

    sendCandidate() {
      const newModel: CandidateAddModel = new CandidateAddModel();
      newModel.name = this.newCandidateName;

      this.votingService.postNewCandidates(newModel).subscribe(
        (x) => { 
          this.newCandidateName = '';
          this.getCandidates(); 
        });
    }

    sendVoter() {
      const newModel: VoterAddModel = new VoterAddModel();
      newModel.name = this.newVoterName;

      this.votingService.postNewVoter(newModel).subscribe(
        (x) => {
          this.newVoterName = ''; 
          this.getVoters(); 
        });
    }
  }
  