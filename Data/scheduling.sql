-- SQLite
DROP TABLE MeetingParticipants;
DROP TABLE User;
DROP TABLE Meeting;


CREATE TABLE User (
    UserId integer Primary KEY,
    UserName TEXT NOT NULL,
    FirstName TEXT,
    LastName TEXT,
    Email  TEXT
);
CREATE TABLE Meeting (
    MeetingId INTEGER PRIMARY KEY,
    MeetingSubject TEXT NOT NULL,
    Date TEXT NOT NULL,
    EndTime TEXT,
    Time TEXT NOT NULL
);
CREATE TABLE MeetingParticipants (
    MeetingId INT NOT NULL,
    UserId Int NOT NULL,
    CONSTRAINT "PK_MeetingParticipants" PRIMARY KEY ("MeetingId", "UserId"),
    CONSTRAINT "FK_MeetingParticipants_Meeting_MeetingId" FOREIGN KEY ("MeetingId") REFERENCES "Meeting" ("MeetingId") ON DELETE CASCADE,
    CONSTRAINT "FK_MeetingParticipants_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("UserId") ON DELETE CASCADE
);
