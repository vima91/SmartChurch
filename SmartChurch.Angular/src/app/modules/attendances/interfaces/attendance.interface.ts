export interface IAttendance {
    Id: number;
    ServiceId: number;
    ServiceName: string;
    PersonId: number;
    PersonName: string;
    DateOfEvent: string;
    IsAttended: boolean;
    Comment: string;
}