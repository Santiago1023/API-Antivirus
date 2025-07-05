# Deploying to Render with Docker

## Prerequisites
- Push your code to a GitHub repository
- Ensure your PostgreSQL connection string is configured for production

## Steps to Deploy on Render

1. **Create a new Web Service on Render**
   - Go to [Render Dashboard](https://dashboard.render.com/)
   - Click "New" → "Web Service"
   - Connect your GitHub repository

2. **Configure the Service**
   - **Environment**: Docker
   - **Region**: Choose your preferred region
   - **Branch**: main (or your default branch)
   - **Root Directory**: Leave empty (Dockerfile is in root)

3. **Environment Variables**
   Add these environment variables in Render:
   ```
   ASPNETCORE_ENVIRONMENT=Production
   ConnectionStrings__DefaultConnection=your_postgresql_connection_string
   Jwt__Key=your_jwt_secret_key
   Jwt__Issuer=your_issuer
   Jwt__Audience=your_audience
   ```

4. **Database Setup**
   - Create a PostgreSQL database on Render
   - Use the internal connection string for your app
   - Run migrations after deployment

5. **Deploy**
   - Click "Create Web Service"
   - Render will automatically build and deploy your Docker container

## Important Notes
- The app will be available on port 8080 (configured in Dockerfile)
- Swagger UI will be accessible at: `https://your-app-name.onrender.com/swagger`
- Make sure to update CORS settings if needed for your frontend domain