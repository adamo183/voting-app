import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../config/environment";
import { map } from "rxjs/operators";
import { Observable } from "rxjs/internal/Observable";
import { Voter } from "src/app/models/voter";
import { Candidate } from "src/app/models/candidate";
import { VoterAddModel } from "src/app/models/voterAddModel";
import { CandidateAddModel } from "src/app/models/candidateAddModel";
import { VoteModel } from "src/app/models/voteModel";

@Injectable({
  providedIn: 'root'
})
export class VotingService {
  
    constructor(
      private httpClient: HttpClient) { }

      getVoters() : Observable<Array<Voter>> { 
        return this.httpClient.get<Array<Voter>>(`${environment.baseUrl}/Voters/all`)
      }
  
      getCandidates(): Observable<Array<Candidate>> {
        return this.httpClient.get<Array<Candidate>>(`${environment.baseUrl}/Candidate/all`);
      }

      postNewVoter(modelToAdd: VoterAddModel) : Observable<boolean> {  
        return this.httpClient.post<boolean>(`${environment.baseUrl}/Voters`, modelToAdd);
      }
  
      postNewCandidates(modelToAdd: CandidateAddModel): Observable<boolean> {
        return this.httpClient.post<boolean>(`${environment.baseUrl}/Candidate`,modelToAdd);
      }
      
      postNewVote(modelToAdd: VoteModel): Observable<boolean> {
        return this.httpClient.put<boolean>(`${environment.baseUrl}/Vote`,modelToAdd);
      }
}