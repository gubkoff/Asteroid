using UnityEngine;

namespace Asteroid.GameLogic.Core
{
    public static class CoordinateHelper
    {
        private const float MIN_RND = 10f;
        private const float MAX_RND = 100f;
        private static Vector3 screenBoundary;

        static CoordinateHelper()
        {
            SetScreenBounds();
        }

        private static void SetScreenBounds()
        {
            screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                Camera.main.transform.position.z));
        }

        public static Vector3 GetRandomCoordinatesOutOfScreen()
        {
            float xRnd = Random.Range(MIN_RND, MAX_RND);
            float zRnd = Random.Range(MIN_RND, MAX_RND);
            float xRndSign = Mathf.Sign(Random.Range(-1, 1));
            float zRndSign = Mathf.Sign(Random.Range(-1, 1));

            Vector3 coord = new Vector3(xRndSign * (xRnd + screenBoundary.x), 0, zRndSign * (zRnd + screenBoundary.z));
            return coord;
        }

        public static bool IsOutOfScreen(Vector3 position, Vector3 boundary)
        {
            var objectPosition = new Vector3(Mathf.Abs(position.x) - boundary.x, Mathf.Abs(position.y) - boundary.y,
                Mathf.Abs(position.z) - boundary.z);
            if (objectPosition.x > screenBoundary.x || objectPosition.z > screenBoundary.z)
            {
                return true;
            }

            return false;
        }

        public static Vector3 GetOppositeScreenSidePosition(Vector3 position, Vector3 boundary)
        {
            var xPos = position.x;
            var zPos = position.z;
            var resultBoundary = new Vector3(screenBoundary.x + boundary.x, 0f, screenBoundary.z + boundary.z);

            if (Mathf.Abs(position.x) > resultBoundary.x)
            {
                xPos = -Mathf.Sign(position.x) * resultBoundary.x;
            }
            else if (Mathf.Abs(position.z) > resultBoundary.z)
            {
                zPos = -Mathf.Sign(position.z) * resultBoundary.z;
            }

            return new Vector3(xPos, 0, zPos);
        }
        
        public static Quaternion GetRandomRotateByY()
        {
            return Quaternion.Euler(0, Random.Range(-180f, 180f), 0);
        }
    }
}