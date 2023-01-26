# Use an official .NET runtime as the base image
FROM mcr.microsoft.com/dotnet/sdk:5.0

# Set the working directory in the container
WORKDIR /app

# Copy the current folder to the container
COPY . .

# Restore the dependencies
RUN dotnet restore

# Build the application
RUN dotnet build --configuration Release

# Make port 80 available to the world outside this container
EXPOSE 80

# Run the application
CMD ["dotnet", "run", "--urls", "http://*:80"]