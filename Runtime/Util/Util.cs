namespace WiseMonkeES.Util
{
       
    using UnityEngine;
    public class Mouse
    {
        /// <summary>
        /// Returns the mouse position in world space.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static Vector3 GetWorldPosition(Camera camera)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -camera.transform.position.z;
            Vector3 worldPosition = camera.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0f;
            return worldPosition;
        }
        
        /// <summary>
        /// Returns the object that is clicked on.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static GameObject Raycast(Camera camera)
        {
            Vector3 mousePosition = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                return hit.collider.gameObject;
            }
            return null;
        }
                        
        /// <summary>
        /// Returns the object that is clicked on.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static GameObject Raycast(Camera camera, float distance)
        {
            Vector3 mousePosition = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(mousePosition), Vector2.zero, distance);
            if (hit.collider != null)
            {
                return hit.collider.gameObject;
            }
            return null;
        }
                        
        /// <summary>
        /// Returns the object that is clicked on.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static GameObject Raycast(Camera camera, string tag)
        {
            Vector3 mousePosition = Input.mousePosition;

            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag(tag))
                {
                    return hit.collider.gameObject;
                }
            }
            return null;
        }
                        
        /// <summary>
        /// Returns the object that is clicked on.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public static GameObject Raycast(Camera camera, string[] tags)
        {
            Vector3 mousePosition = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                foreach (string tag in tags)
                {
                    if (hit.collider.gameObject.CompareTag(tag))
                    {
                        return hit.collider.gameObject;
                    }
                }
            }
            return null;
        }
                        
        /// <summary>
        /// Returns the object that is clicked on.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="tag"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static GameObject Raycast(Camera camera, string tag, float distance)
        {
            Vector3 mousePosition = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(mousePosition), Vector2.zero, distance);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag(tag))
                {
                    return hit.collider.gameObject;
                }
            }
            return null;
        }
                        
        /// <summary>
        /// Returns the object that is clicked on.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="tags"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static GameObject Raycast(Camera camera, string[] tags, float distance)
        {
            Vector3 mousePosition = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(mousePosition), Vector2.zero, distance);
            if (hit.collider != null)
            {
                foreach (string tag in tags)
                {
                    if (hit.collider.gameObject.CompareTag(tag))
                    {
                        return hit.collider.gameObject;
                    }
                }
            }
            return null;
                                
        }
                        
                        
    }
        
}