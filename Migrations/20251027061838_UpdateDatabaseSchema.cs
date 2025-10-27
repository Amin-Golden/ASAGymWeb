using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gym.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Clients_ClientId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Sessions_SessionId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_GymSessions_Clients_ClientId",
                table: "GymSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Packages_PackageId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Clients_ClientId",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Instructors_InstructorId",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Packages_PackageId",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Instructors_InstructorId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Memberships_MembershipId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymSessions",
                table: "GymSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "Sessions",
                newName: "sessions");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "payments");

            migrationBuilder.RenameTable(
                name: "Packages",
                newName: "packages");

            migrationBuilder.RenameTable(
                name: "Memberships",
                newName: "memberships");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "instructors");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "clients");

            migrationBuilder.RenameTable(
                name: "GymSessions",
                newName: "gym_sessions");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "attendance");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "sessions",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sessions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "sessions",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "MembershipId",
                table: "sessions",
                newName: "membership_id");

            migrationBuilder.RenameColumn(
                name: "IsAttended",
                table: "sessions",
                newName: "is_attended");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "sessions",
                newName: "instructor_id");

            migrationBuilder.RenameColumn(
                name: "DestinationDate",
                table: "sessions",
                newName: "destination_date");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "sessions",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_MembershipId",
                table: "sessions",
                newName: "IX_sessions_membership_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_InstructorId",
                table: "sessions",
                newName: "IX_sessions_instructor_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "payments",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "payments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "payments",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "payments",
                newName: "payment_type");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "payments",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "payments",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_ClientId",
                table: "payments",
                newName: "IX_payments_client_id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "packages",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "packages",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "packages",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Days",
                table: "packages",
                newName: "days");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "packages",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "packages",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PackageName",
                table: "packages",
                newName: "package_name");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "packages",
                newName: "image_path");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "packages",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "memberships",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "memberships",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "memberships",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "memberships",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "memberships",
                newName: "payment_date");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "memberships",
                newName: "package_id");

            migrationBuilder.RenameColumn(
                name: "MembershipStatus",
                table: "memberships",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "memberships",
                newName: "is_paid");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "memberships",
                newName: "instructor_id");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "memberships",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "memberships",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "memberships",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_PackageId",
                table: "memberships",
                newName: "IX_memberships_package_id");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_IsPaid",
                table: "memberships",
                newName: "IX_memberships_is_paid");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_InstructorId",
                table: "memberships",
                newName: "IX_memberships_instructor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_EndDate",
                table: "memberships",
                newName: "IX_memberships_end_date");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_ClientId",
                table: "memberships",
                newName: "IX_memberships_client_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "instructors",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "instructors",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "instructors",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "instructors",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "instructors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "instructors",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "instructors",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "instructors",
                newName: "package_id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "instructors",
                newName: "lname");

            migrationBuilder.RenameColumn(
                name: "IsMale",
                table: "instructors",
                newName: "is_male");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "instructors",
                newName: "image_path");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "instructors",
                newName: "fname");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "instructors",
                newName: "dob");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "instructors",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_PackageId",
                table: "instructors",
                newName: "IX_instructors_package_id");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "clients",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Locker",
                table: "clients",
                newName: "locker");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "clients",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "clients",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "clients",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "clients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "clients",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "SocialNumber",
                table: "clients",
                newName: "social_number");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "clients",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "clients",
                newName: "lname");

            migrationBuilder.RenameColumn(
                name: "IsMale",
                table: "clients",
                newName: "is_male");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "clients",
                newName: "image_path");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "clients",
                newName: "fname");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "clients",
                newName: "dob");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "clients",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_Locker",
                table: "clients",
                newName: "IX_clients_locker");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_SocialNumber",
                table: "clients",
                newName: "IX_clients_social_number");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_PhoneNumber",
                table: "clients",
                newName: "IX_clients_phone_number");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "gym_sessions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LockerNumber",
                table: "gym_sessions",
                newName: "locker_number");

            migrationBuilder.RenameColumn(
                name: "ExitTime",
                table: "gym_sessions",
                newName: "exit_time");

            migrationBuilder.RenameColumn(
                name: "EntranceTime",
                table: "gym_sessions",
                newName: "entrance_time");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "gym_sessions",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "gym_sessions",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_GymSessions_ExitTime",
                table: "gym_sessions",
                newName: "IX_gym_sessions_exit_time");

            migrationBuilder.RenameIndex(
                name: "IX_GymSessions_EntranceTime",
                table: "gym_sessions",
                newName: "IX_gym_sessions_entrance_time");

            migrationBuilder.RenameIndex(
                name: "IX_GymSessions_ClientId",
                table: "gym_sessions",
                newName: "IX_gym_sessions_client_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "attendance",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "attendance",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "attendance",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "attendance",
                newName: "session_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "attendance",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "attendance",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_SessionId",
                table: "attendance",
                newName: "IX_attendance_session_id");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_ClientId",
                table: "attendance",
                newName: "IX_attendance_client_id");

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "packages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "days",
                table: "packages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sessions",
                table: "sessions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payments",
                table: "payments",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_packages",
                table: "packages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_memberships",
                table: "memberships",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instructors",
                table: "instructors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clients",
                table: "clients",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gym_sessions",
                table: "gym_sessions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_attendance",
                table: "attendance",
                column: "id");

            migrationBuilder.CreateTable(
                name: "access_logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<long>(type: "bigint", nullable: true),
                    access_granted = table.Column<bool>(type: "boolean", nullable: false),
                    confidence = table.Column<float>(type: "real", nullable: true),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_access_logs_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adminID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    fname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_male = table.Column<bool>(type: "boolean", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "face_embeddings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<long>(type: "bigint", nullable: false),
                    embedding = table.Column<byte[]>(type: "bytea", nullable: false),
                    confidence = table.Column<float>(type: "real", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_face_embeddings", x => x.id);
                    table.ForeignKey(
                        name: "FK_face_embeddings_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_access_logs_access_granted",
                table: "access_logs",
                column: "access_granted");

            migrationBuilder.CreateIndex(
                name: "IX_access_logs_client_id",
                table: "access_logs",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_access_logs_timestamp",
                table: "access_logs",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_face_embeddings_client_id",
                table: "face_embeddings",
                column: "client_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_clients_client_id",
                table: "attendance",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_sessions_session_id",
                table: "attendance",
                column: "session_id",
                principalTable: "sessions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gym_sessions_clients_client_id",
                table: "gym_sessions",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_packages_package_id",
                table: "instructors",
                column: "package_id",
                principalTable: "packages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_memberships_clients_client_id",
                table: "memberships",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_memberships_instructors_instructor_id",
                table: "memberships",
                column: "instructor_id",
                principalTable: "instructors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_memberships_packages_package_id",
                table: "memberships",
                column: "package_id",
                principalTable: "packages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_clients_client_id",
                table: "payments",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessions_instructors_instructor_id",
                table: "sessions",
                column: "instructor_id",
                principalTable: "instructors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessions_memberships_membership_id",
                table: "sessions",
                column: "membership_id",
                principalTable: "memberships",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendance_clients_client_id",
                table: "attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_attendance_sessions_session_id",
                table: "attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_gym_sessions_clients_client_id",
                table: "gym_sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_packages_package_id",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_memberships_clients_client_id",
                table: "memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_memberships_instructors_instructor_id",
                table: "memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_memberships_packages_package_id",
                table: "memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_clients_client_id",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_sessions_instructors_instructor_id",
                table: "sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_sessions_memberships_membership_id",
                table: "sessions");

            migrationBuilder.DropTable(
                name: "access_logs");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "face_embeddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sessions",
                table: "sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_payments",
                table: "payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_packages",
                table: "packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_memberships",
                table: "memberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instructors",
                table: "instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clients",
                table: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gym_sessions",
                table: "gym_sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_attendance",
                table: "attendance");

            migrationBuilder.RenameTable(
                name: "sessions",
                newName: "Sessions");

            migrationBuilder.RenameTable(
                name: "payments",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "packages",
                newName: "Packages");

            migrationBuilder.RenameTable(
                name: "memberships",
                newName: "Memberships");

            migrationBuilder.RenameTable(
                name: "instructors",
                newName: "Instructors");

            migrationBuilder.RenameTable(
                name: "clients",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "gym_sessions",
                newName: "GymSessions");

            migrationBuilder.RenameTable(
                name: "attendance",
                newName: "Attendances");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Sessions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sessions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Sessions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "membership_id",
                table: "Sessions",
                newName: "MembershipId");

            migrationBuilder.RenameColumn(
                name: "is_attended",
                table: "Sessions",
                newName: "IsAttended");

            migrationBuilder.RenameColumn(
                name: "instructor_id",
                table: "Sessions",
                newName: "InstructorId");

            migrationBuilder.RenameColumn(
                name: "destination_date",
                table: "Sessions",
                newName: "DestinationDate");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Sessions",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_sessions_membership_id",
                table: "Sessions",
                newName: "IX_Sessions_MembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_sessions_instructor_id",
                table: "Sessions",
                newName: "IX_Sessions_InstructorId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Payments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Payments",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "payment_type",
                table: "Payments",
                newName: "PaymentType");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Payments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "Payments",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_payments_client_id",
                table: "Payments",
                newName: "IX_Payments_ClientId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Packages",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Packages",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Packages",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "days",
                table: "Packages",
                newName: "Days");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Packages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Packages",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "package_name",
                table: "Packages",
                newName: "PackageName");

            migrationBuilder.RenameColumn(
                name: "image_path",
                table: "Packages",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Packages",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Memberships",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Memberships",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Memberships",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Memberships",
                newName: "MembershipStatus");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Memberships",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "payment_date",
                table: "Memberships",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "package_id",
                table: "Memberships",
                newName: "PackageId");

            migrationBuilder.RenameColumn(
                name: "is_paid",
                table: "Memberships",
                newName: "IsPaid");

            migrationBuilder.RenameColumn(
                name: "instructor_id",
                table: "Memberships",
                newName: "InstructorId");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "Memberships",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Memberships",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "Memberships",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_memberships_package_id",
                table: "Memberships",
                newName: "IX_Memberships_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_memberships_is_paid",
                table: "Memberships",
                newName: "IX_Memberships_IsPaid");

            migrationBuilder.RenameIndex(
                name: "IX_memberships_instructor_id",
                table: "Memberships",
                newName: "IX_Memberships_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_memberships_end_date",
                table: "Memberships",
                newName: "IX_Memberships_EndDate");

            migrationBuilder.RenameIndex(
                name: "IX_memberships_client_id",
                table: "Memberships",
                newName: "IX_Memberships_ClientId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Instructors",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "salary",
                table: "Instructors",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Instructors",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Instructors",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Instructors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Instructors",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Instructors",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "package_id",
                table: "Instructors",
                newName: "PackageId");

            migrationBuilder.RenameColumn(
                name: "lname",
                table: "Instructors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "is_male",
                table: "Instructors",
                newName: "IsMale");

            migrationBuilder.RenameColumn(
                name: "image_path",
                table: "Instructors",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "fname",
                table: "Instructors",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "dob",
                table: "Instructors",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Instructors",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_instructors_package_id",
                table: "Instructors",
                newName: "IX_Instructors_PackageId");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "Clients",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "locker",
                table: "Clients",
                newName: "Locker");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "Clients",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Clients",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Clients",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Clients",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "social_number",
                table: "Clients",
                newName: "SocialNumber");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Clients",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "lname",
                table: "Clients",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "is_male",
                table: "Clients",
                newName: "IsMale");

            migrationBuilder.RenameColumn(
                name: "image_path",
                table: "Clients",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "fname",
                table: "Clients",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "dob",
                table: "Clients",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Clients",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_clients_locker",
                table: "Clients",
                newName: "IX_Clients_Locker");

            migrationBuilder.RenameIndex(
                name: "IX_clients_social_number",
                table: "Clients",
                newName: "IX_Clients_SocialNumber");

            migrationBuilder.RenameIndex(
                name: "IX_clients_phone_number",
                table: "Clients",
                newName: "IX_Clients_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "GymSessions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "locker_number",
                table: "GymSessions",
                newName: "LockerNumber");

            migrationBuilder.RenameColumn(
                name: "exit_time",
                table: "GymSessions",
                newName: "ExitTime");

            migrationBuilder.RenameColumn(
                name: "entrance_time",
                table: "GymSessions",
                newName: "EntranceTime");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "GymSessions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "GymSessions",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_gym_sessions_exit_time",
                table: "GymSessions",
                newName: "IX_GymSessions_ExitTime");

            migrationBuilder.RenameIndex(
                name: "IX_gym_sessions_entrance_time",
                table: "GymSessions",
                newName: "IX_GymSessions_EntranceTime");

            migrationBuilder.RenameIndex(
                name: "IX_gym_sessions_client_id",
                table: "GymSessions",
                newName: "IX_GymSessions_ClientId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Attendances",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Attendances",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Attendances",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "session_id",
                table: "Attendances",
                newName: "SessionId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Attendances",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "Attendances",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_attendance_session_id",
                table: "Attendances",
                newName: "IX_Attendances_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_attendance_client_id",
                table: "Attendances",
                newName: "IX_Attendances_ClientId");

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "Packages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Days",
                table: "Packages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymSessions",
                table: "GymSessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Clients_ClientId",
                table: "Attendances",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Sessions_SessionId",
                table: "Attendances",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GymSessions_Clients_ClientId",
                table: "GymSessions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Packages_PackageId",
                table: "Instructors",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Clients_ClientId",
                table: "Memberships",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Instructors_InstructorId",
                table: "Memberships",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Packages_PackageId",
                table: "Memberships",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Instructors_InstructorId",
                table: "Sessions",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Memberships_MembershipId",
                table: "Sessions",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
